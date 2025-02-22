using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.Product
{
   public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength (255 ,ErrorMessage = "تعداد کاراکتر 255 می باشد")]
        public string Name { get;  set; }

        public string Code { get; set; }



        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string Slug { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Picture { get; set; }
        public string PictureString { get; set; }

        [MaxFileSize(4 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile ManualFile { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(255, ErrorMessage = "تعداد کاراکتر 255 می باشد")]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string PictureTitle { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get; set; }

        [Range(1, 10000000, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر 150 می باشد")]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = "تعداد کاراکتر 80 می باشد")]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get; set; }


        public string StarBolt { get; set; }

        public long ShopType { get; set; }
        public string Description { get; set; }

        public bool CommentActive { get;  set; }

        public List<ProductCategoryViewModel> Categories { get; set; }

        public List<LanguageViewModel> ListLanguage { get; set; }
    }
}
