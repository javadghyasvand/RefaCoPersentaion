using System.Collections.Generic;
using My_Shop_Framework.Domain;
using ShopManagement.Application.Contracts.Product;


namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        List<ProductViewModel> Search(ProductSearchModel model);
        List<ProductViewModel> GetProducts();
        EditProduct GetDetails(long id);
        ProductViewModel GetProduct(long id);
        string GetProductName(long id);
        List<ProductViewModel> List();
    }
}
