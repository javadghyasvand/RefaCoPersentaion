using System.ComponentModel.DataAnnotations;

namespace My_Shop_Framework.Application
{
    public class InternationalPhoneNumberAttribute : ValidationAttribute
    {
        public InternationalPhoneNumberAttribute()
        {
            ErrorMessage = "لطفاً یک شماره تلفن معتبر بین‌المللی وارد کنید (مثلاً: +1234567890).";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var phoneNumber = value.ToString();

            // الگوی اعتبارسنجی شماره تلفن به فرمت بین‌المللی (E.164)
            var regex = new System.Text.RegularExpressions.Regex(@"^\+?[1-9]\d{1,14}$");

            if (!regex.IsMatch(phoneNumber))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}