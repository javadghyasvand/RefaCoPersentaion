﻿using System.Globalization;
using System.Linq;
using ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction;
using ComplaintAndSatisfaction.Infrastructure.EFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_ShopQuery.Contract.Language;
using My_ShopQuery.Contract.Product;
using My_ShopQuery.Contract.Support;

namespace ServiceHost.Pages.Support
{
    public class ComplaintModel : PageModel
    {
        private readonly ISupportQueryModel _supportQueryModel;
        private readonly IProductQueryModel _productQuery;
        private readonly ILanguageQueryModel _langContext;
        private readonly IComplaintAndSatisfactionApplication _complaintAndSatisfactionApplication;

        public SelectList Products { get; private set; }
        public SelectList Satisfaction { get; private set; }
        public SupportQueryModel SupportQueryModel { get; private set; }

        public ComplaintModel(
            ISupportQueryModel supportQueryModel,
            IProductQueryModel productQuery,
            ILanguageQueryModel langContext,
            IComplaintAndSatisfactionApplication complaintAndSatisfactionApplication)
        {
            _supportQueryModel = supportQueryModel;
            _productQuery = productQuery;
            _langContext = langContext;
            _complaintAndSatisfactionApplication = complaintAndSatisfactionApplication;
        }

        public void OnGet()
        {
            LoadSelectLists();
            SupportQueryModel = _supportQueryModel.GetSupportQuery();
        }

        public IActionResult OnPost(CreateComplaintAndSatisfaction commend)
        {

            if (ModelState.IsValid)
            {
                commend.ParentName = ComplaintAndSatisfactionType.ComplaintStr;
                var currentLanguage = CultureInfo.CurrentCulture.ToString();
                var language = _langContext.GetBy(currentLanguage);
                var satisfactionLevelItems =
                    SatisfactionLevelItemService.GetComplaintAndSatisfactionList(language.Language);

                commend.SatisfactionName = satisfactionLevelItems
                    .FirstOrDefault(x => x.Id == commend.SatisfactionLevel)?.Name ?? "نامشخص";
                commend.ProductName = _productQuery.GetBy(commend.ProductId)?.Name ?? "نامشخص";

                var operationResult = _complaintAndSatisfactionApplication.Create(commend);
                if (operationResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "عملیات با موفقیت انجام شد";
                    return RedirectToPage("/Success/Success");
                }
            }
            LoadSelectLists();
            SupportQueryModel = _supportQueryModel.GetSupportQuery();
            //TempData["ErrorMessage"] = "خطایی رخ داده است، لطفاً دوباره تلاش کنید.";
            Response.Clear();

            return RedirectToPage("/Success", routeValues: null);
        }

        private void LoadSelectLists()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var language = _langContext.GetBy(currentLanguage);

            Products = new SelectList(_productQuery.GetList(), "Id", "Name");
            Satisfaction = new SelectList(
                SatisfactionLevelItemService.GetComplaintAndSatisfactionList(language.Language),
                "Id", "Name");
        }
    }
}