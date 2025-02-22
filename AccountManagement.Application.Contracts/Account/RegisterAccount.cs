using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace AccountManagement.Application.Contracts.Account
{
    public class RegisterAccount
    {
        
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر 350 می باشد")]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر 350 می باشد")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر 350 می باشد")]
        public string LastName { get; set; }

        /*[Required(ErrorMessage = ValidationMessages.IsRequired)]*/
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string UserName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر 50 می باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفاً تکرار رمز عبور را وارد کنید")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن باید یکسان باشند")]
        public string RePassword { get; set; }

        [MaxLength(20, ErrorMessage = "تعداد کاراکتر 20 می باشد")]
        public string Mobile { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile ProfilePhoto { get; set; }

        public string PictureString { get; set; }
      
        public long RoleId { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public List<string> AllRoles { get; set; }
        public List<string> SelectedRoles { get; set; } 
    }
}
 