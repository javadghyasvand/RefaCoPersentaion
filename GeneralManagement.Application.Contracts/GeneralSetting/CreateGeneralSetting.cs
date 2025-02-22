using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LanguageManagement.Application.Contracts.Language;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.GeneralSetting
{
    public class CreateGeneralSetting
    {

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string SiteTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(180, ErrorMessage = "تعداد کاراکتر 180 مجاز می باشد")]
        public string MetaDescription { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر 250 مجاز می باشد")]
        public string MetaKeywords { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string AdminEmail { get;  set; }

        public string HostingSpace { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Address { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PostalCode { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PhoneNumbers { get; set; }

        public string MapLink { get;  set; }


        [Range(1,long.MaxValue ,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get;  set; }

        public string WaysLink { get;  set; }
        public string BaladLink { get;  set; }
        public string GoogleLink { get;  set; }
        public List<LanguageViewModel> LanguageList { get; set; }
 

    }
}
