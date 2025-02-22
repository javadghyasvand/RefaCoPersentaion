using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class AccountSearchModel
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string UserName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string Mobile { get; set; }

        public long RoleId { get; set; }
    }
}