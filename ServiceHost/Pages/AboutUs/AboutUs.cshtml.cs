using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.AboutUs;
using My_ShopQuery.Contract.Footer;
using My_ShopQuery.Contract.GeneralSetting;
using My_ShopQuery.Contract.SiteLogo;
using My_ShopQuery.Contract.SocialMedia;
using My_ShopQuery.Query;

namespace ServiceHost.Pages.AboutUs
{
    public class AboutUsModel : PageModel
    {
        public AboutUsQueryModel AboutUsQueryModel;
        public GeneralSettingQueryModel GeneralSettingQuery;
        private readonly IAboutUsQueryModel _aboutUsQuery;
        private readonly IGeneralSettingQueryModel _generalSettingQueryModel;

        public AboutUsModel(IAboutUsQueryModel aboutUsQuery, IGeneralSettingQueryModel generalSettingQueryModel)
        {
            _aboutUsQuery = aboutUsQuery;
            _generalSettingQueryModel = generalSettingQueryModel;
        }


        public void OnGet()
        {
            GeneralSettingQuery = _generalSettingQueryModel.GeneralSettingQueryModel();
            AboutUsQueryModel = _aboutUsQuery.AboutUs();
        }
    }
}
