using System.Collections.Generic;

namespace My_ShopQuery.Contract.Product
{
    public interface IProductQueryModel
    {
        List<ProductQueryModel> GetLatestProduct();
        ProductQueryModel GetProductDetails(string slug);
        List<ProductQueryModel> SearchProducts(string value);
        List<ProductQueryModel> GetList();
        List<ProductQueryModel> List();
        ProductQueryModel GetBy(long id);
    }
}