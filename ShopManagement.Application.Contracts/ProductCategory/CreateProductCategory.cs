
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;
using LanguageManagement.Application.Contracts.Language;

namespace ShopManagement.Application.Contracts.ProductCategory
{
   public  class CreateProductCategory
    {
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        [MaxLength(255,ErrorMessage = "تعداد کاراکتر 255 می باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر 300 می باشد")]
        public string Slug { get; set; }

        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string Description { get; set; }
        
        [MaxFileSize(1*1024*1024,ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string []{ ".jpeg" , ".png" , ".webp",".jpg"},ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Picture { get; set; }
        public string PictureString { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".webp", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Icon { get; set; }
        public string IconString { get; set; }



        [MaxLength(255, ErrorMessage = "تعداد کاراکتر 255 می باشد")]
        public string PictureAlt { get; set; }

        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = "تعداد کاراکتر 80 می باشد")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر 150 می باشد")]
        public string MetaDescription { get; set; }

      

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get; set; }


        public List<LanguageViewModel> ListLanguage { get; set; }
    }
}
  