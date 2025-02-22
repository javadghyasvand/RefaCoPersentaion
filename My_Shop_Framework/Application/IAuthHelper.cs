using System.Collections.Generic;

namespace My_Shop_Framework.Application
{
    public interface IAuthHelper
    {
        void SignIn(AuthViewModel account);
        void SignOut();
        bool IsAuthenticated();
        string CurrentAccount();
        AuthViewModel CurrentAccountInfo();
        List<long> GetPermissions();
        long CurrentAccountId();
        string CurrentMobile();
    }
}
