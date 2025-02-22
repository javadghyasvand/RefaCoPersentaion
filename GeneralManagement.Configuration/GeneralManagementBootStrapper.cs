using GeneralManagement.Application;
using GeneralManagement.Application.Contracts.AboutUs;
using GeneralManagement.Application.Contracts.Certificate;
using GeneralManagement.Application.Contracts.Faq;
using GeneralManagement.Application.Contracts.Gallery;
using GeneralManagement.Application.Contracts.GeneralSetting;
using GeneralManagement.Application.Contracts.SiteLogo;
using GeneralManagement.Application.Contracts.SocialMedia;
using GeneralManagement.Application.Contracts.Warranty;
using GeneralManagement.Domain.AboutAgg;
using GeneralManagement.Domain.CertificateAgg;
using GeneralManagement.Domain.FaqAgg;
using GeneralManagement.Domain.GalleryAgg;
using GeneralManagement.Domain.GeneralAgg;
using GeneralManagement.Domain.LogoAgg;
using GeneralManagement.Domain.SocialMediaAgg;
using GeneralManagement.Domain.WarrantyAgg;
using GeneralManagement.Infrastructure.EFCore;
using GeneralManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_ShopQuery.Contract.AboutUs;
using My_ShopQuery.Contract.Certificate;
using My_ShopQuery.Contract.Faq;
using My_ShopQuery.Contract.Galley;
using My_ShopQuery.Contract.GeneralSetting;
using My_ShopQuery.Contract.SiteLogo;
using My_ShopQuery.Contract.SocialMedia;
using My_ShopQuery.Contract.Support;
using My_ShopQuery.Query;

namespace GeneralManagement.Configuration
{
    public class GeneralManagementBootStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {

            service.AddTransient<IAboutUsApplication, AboutUsApplication>();
            service.AddTransient<IAboutUsRepository, AboutUsRepository>();

            service.AddTransient<IGeneralSettingRepository, GeneralSettingRepository>();
            service.AddTransient<IGeneralSettingApplication, GeneralSettingApplication>();

            service.AddTransient<ISiteLogoRepository, SiteLogoRepository>();
            service.AddTransient<ISiteLogoApplication, SiteLogoApplication>();

            service.AddTransient<ISocialMediaRepository, SocialMediaRepository>();
            service.AddTransient<ISocialMediaApplication, SocialMediaApplication>();

            service.AddTransient<ICertificateRepository, CertificateRepository>();
            service.AddTransient<ICertificateApplication, CertificateApplication>();

            service.AddTransient<IFaqRepository, FaqRepository>();
            service.AddTransient<IFaqApplication, FaqApplication>();


            service.AddTransient<IGalleryRepository, GalleryRepository>();
            service.AddTransient<IGalleryApplication, GalleryApplication>();

            service.AddTransient<IWarrantyRepository, WarrantyRepository>();
            service.AddTransient<IWarrantyApplication, WarrantyApplication>();

            service.AddTransient<ISocialMediaQueryModel, SocialMediaQuery>();
            service.AddTransient<ISiteLogoQueryModel, SiteLogoQuery>();
            service.AddTransient<IAboutUsQueryModel, AboutUsQuery>();
            service.AddTransient<IGeneralSettingQueryModel, GeneralSettingQuery>();
            service.AddTransient<ICertificateQueryModel, CertificateQuery>();
            service.AddTransient<IFaqQueryModel, FaqQuery>();
            service.AddTransient<IGalleryQueryModel,GalleryQuery>();
            service.AddTransient<ISupportQueryModel,SupportQuery>();

            service.AddDbContext<GeneralContext>(x => x.UseSqlServer(connectionString));

        }
    }

}
