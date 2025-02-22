using System.Collections.Generic;
using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;
using My_Shop_Framework.Infrastructure;

namespace AccountManagement.Application.Contracts.Role
{
    public class CreateRole
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر 350 می باشد")]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string PersianName { get; set; }
        public List<long> Permissions { get; set; }


    }
}