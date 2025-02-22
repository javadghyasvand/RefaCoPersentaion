using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore;
using AccountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IAccountRepository, AccountRepository>();
            service.AddTransient<IAccountApplication, AccountApplication>();

            service.AddTransient<IRoleApplication, RoleApplication>();
            service.AddTransient<IRoleRepository, RoleRepository>();

            service.AddTransient<IMessageService, MessageService>();

            service.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}