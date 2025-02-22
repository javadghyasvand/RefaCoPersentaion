using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Warranty;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.General.Warranty
{
   
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<WarrantyViewModel> Warranties;

        private readonly IWarrantyApplication _warrantyApplication;

        public IndexModel(IWarrantyApplication warrantyApplication)
        {
            _warrantyApplication = warrantyApplication;
        }


        public void OnGet()
        {
            Warranties = _warrantyApplication.List();
        }

    }
}
