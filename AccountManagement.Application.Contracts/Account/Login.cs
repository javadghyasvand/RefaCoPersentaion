using System.ComponentModel.DataAnnotations;
using My_Shop_Framework.Application;

namespace AccountManagement.Application.Contracts.Account
{
    public class Login
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
    }
}