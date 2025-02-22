using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.SocialMedia
{
    public class CreateSocialMedia
    {

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string Title { get;  set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".webp", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Icon { get;  set; }
        public string IconString { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Link { get;  set; }
    }
}
    