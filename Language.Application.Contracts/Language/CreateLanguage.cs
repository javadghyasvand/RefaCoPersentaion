using System.ComponentModel.DataAnnotations;

namespace Language.Application.Contracts.Language
{
    public class CreateLanguage
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string LanguageTitle { get;  set; }
    }
}