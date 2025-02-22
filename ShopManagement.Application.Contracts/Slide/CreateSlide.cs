using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide{

        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(255, ErrorMessage = "تعداد کاراکتر 255 می باشد")]
        public string Heading { get;  set; }

     
        [MaxLength(359, ErrorMessage = "تعداد کاراکتر 359 می باشد")]
        public string Text { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(60, ErrorMessage = "تعداد کاراکتر 60 می باشد")]
        public string BtnText { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Link { get; set; }

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get; set; }

        public List<LanguageViewModel> ListLanguage { get; set; }
    }
}