using System.ComponentModel.DataAnnotations;

namespace My_Shop_Framework.Application
{
    public class MobileNumberAttribute : ValidationAttribute
    {
        public MobileNumberAttribute()
        {
            ErrorMessage = "لطفاً یک شماره موبایل معتبر وارد کنید.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var mobileNumber = value.ToString();

            // الگوی اعتبارسنجی شماره موبایل
            var regex = new System.Text.RegularExpressions.Regex(@"^(\+98|0)?9\d{9}$");

            if (!regex.IsMatch(mobileNumber))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}