using Microsoft.AspNetCore.Identity;

namespace ServiceHost
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = $"نام کاربری '{userName}' از پیش ثبت شده است."
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = $" رمز عبور باید کمتر از {length} کارکتر نباشد. "
            };
        }
    }
}
