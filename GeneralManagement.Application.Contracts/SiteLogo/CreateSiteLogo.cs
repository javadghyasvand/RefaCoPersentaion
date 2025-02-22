using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.SiteLogo
{
    public class CreateSiteLogo
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string Title { get; set; }


        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".webp", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Picture { get; set; }
        public string PictureString { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(1500, ErrorMessage = "تعداد کاراکتر 1500 مجاز می باشد")]
        public string Link { get; set; }

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get; set; }

    }
}
