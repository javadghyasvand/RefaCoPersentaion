using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace GeneralManagement.Application.Contracts.GeneralSetting
{
    public class GeneralSettingViewModel
    {
        public long Id { get; set; }
        public string SiteTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string AdminEmail { get; set; }
        public string HostingSpace { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumbers { get; set; }
        public string MapLink { get; set; }
        public string WaysLink { get; set; }
        public string BaladLink { get; set; }
        public string GoogleLink { get;  set; }
        public long LanguageId { get; set; }

    }
}