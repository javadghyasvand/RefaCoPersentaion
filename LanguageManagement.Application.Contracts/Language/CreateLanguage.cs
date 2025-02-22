using System.ComponentModel.DataAnnotations;
using My_Shop_Framework.Application;

namespace LanguageManagement.Application.Contracts.Language
{
    public class CreateLanguage
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر 300 می باشد")]
        public string LanguageTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500,ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string LanguageNameEn { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string LanguageNameFa { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string LanguageNameRu { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string LanguageNameAr { get; set; }
    }
}