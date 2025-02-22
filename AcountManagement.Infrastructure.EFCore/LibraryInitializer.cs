using System.Linq;
using AccountManagement.Domain.RoleAgg;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.Account.Agg;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore.Repository;

namespace AccountManagement.Infrastructure.EFCore
{
    public class LibraryInitializer
    {
        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly IRoleRepository _roleRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
  
        public LibraryInitializer(IRoleApplication roleApplication, IAccountApplication accountApplication, IRoleRepository roleRepository, IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _roleApplication = roleApplication;
            _accountApplication = accountApplication;
            _roleRepository = roleRepository;
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public void  Initialize()
        {
            // بررسی و ایجاد رول پیش‌فرض
            var roles = _roleApplication.GetRoles();
            if (!roles.Any(r => r.Name == "مدیر سیستم"))
            {
                _roleApplication.Create(new CreateRole()
                {
                    Name ="مدیر سیستم"
                });
            }
            _roleRepository.SaveChanges();
            // بررسی و ایجاد اکانت پیش‌فرض
            var users = _accountApplication.ListAccounts();
            if (users.All(u => u.UserName != "javadghyasvand68@gmail.com"))
            {
               _accountApplication.Register(new RegisterAccount
               {
                   UserName = "javadghyasvand68@gmail.com",
                   FullName = "javadghyasvand",
                   Mobile = "9104802505",
                   Password ="13680821Aj",
                   RoleId = _roleRepository.FirstRoles(),
               });
               
            }
           
            _accountRepository.SaveChanges();
            
        }
    }
}