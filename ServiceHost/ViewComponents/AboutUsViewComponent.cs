using GeneralManagement.Domain.GeneralAgg;
using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.AboutUs;
using My_ShopQuery.Contract.GeneralSetting;

namespace ServiceHost.ViewComponents
{
    public class AboutUsViewComponent:ViewComponent
    {
        private readonly IAboutUsQueryModel _aboutUsQuery;
        private readonly IGeneralSettingQueryModel _generalSettingQuery;

        public AboutUsViewComponent(IAboutUsQueryModel aboutUsQuery, IGeneralSettingQueryModel generalSettingQuery)
        {
            _aboutUsQuery = aboutUsQuery;
            _generalSettingQuery = generalSettingQuery;
        }


        public IViewComponentResult Invoke()
        {
            var aboutUs = _aboutUsQuery.AboutUs();
            return View("Aboutus", aboutUs);
        }
    }
}