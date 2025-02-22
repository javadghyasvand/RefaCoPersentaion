using LanguageManagement.Application;
using LanguageManagement.Application.Contracts.Language;
using LanguageManagement.Domain.Language.Agg;
using LanguageManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_ShopQuery.Contract.Language;
using My_ShopQuery.Query;

namespace LanguageManagement.Configuration
{
    public class LanguageManagementBootStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<ILanguageRepository, LanguageRepository>();
            service.AddTransient<ILanguageApplication, LanguageApplication>();

            service.AddTransient<ILanguageQueryModel, LanguageQuery>();

            service.AddDbContext<LanguageContext>(x => x.UseSqlServer(connectionString));
        }
    }

   
}