using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.AboutUs;
using My_ShopQuery.Contract.GeneralSetting;

namespace ServiceHost.Pages.ContactUs
{
    public class ContactUsModel : PageModel
    {
        public GeneralSettingQueryModel GeneralSettingQuery;
        private readonly IGeneralSettingQueryModel _generalSettingQueryModel;
        private readonly ICommentApplication _commentApplication;
        public ContactUsModel(IGeneralSettingQueryModel generalSettingQueryModel, ICommentApplication commentApplication)
        {
            _generalSettingQueryModel = generalSettingQueryModel;
            _commentApplication = commentApplication;
        }
        public void OnGet()
        {
            GeneralSettingQuery = _generalSettingQueryModel.GeneralSettingQueryModel();
        }
        public IActionResult OnPost(CreateComment commend)
        {
            commend.Type = CommentType.Message;
            var result = _commentApplication.CreateComment(commend);
            if (result.IsSuccess)  // بررسی نتیجه عملیات
            {
                TempData["SuccessMessage"] = "نظر شما با موفقیت ارسال شد.";
                GeneralSettingQuery = _generalSettingQueryModel.GeneralSettingQueryModel();
                return Page();
            }
            TempData["ErrorMessage"] = "ارسال نظر با خطا مواجه شد.";
            GeneralSettingQuery = _generalSettingQueryModel.GeneralSettingQueryModel();
            return Page();
        }
    }
}
