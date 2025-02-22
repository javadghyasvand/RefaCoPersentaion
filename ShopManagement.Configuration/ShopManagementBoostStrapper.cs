
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_Shop_Framework.Infrastructure;
using My_ShopQuery.Contract.Product;
using My_ShopQuery.Contract.ProductCategory;
using My_ShopQuery.Contract.Slide;
using My_ShopQuery.Query;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Configuration.Permissions;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.Slide.Agg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using ICartService = ShopManagement.Application.Contracts.Order.ICartService;

namespace ShopManagement.Configuration
{
    public class ShopManagementBoostStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();

            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IOrderApplication, OrderApplication>();

            service.AddSingleton<ICartService,CartService>();

            service.AddTransient<ISlideApplication, SlideApplication>();
            service.AddTransient<ISlideRepository, SlideRepository>();


            service.AddTransient<ISlideQuery,SlideQuery>();
            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            service.AddTransient<IProductQueryModel, ProductQuery>();


            service.AddTransient<IPermissionsExpose, ShopPermissionExpose>();

            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
