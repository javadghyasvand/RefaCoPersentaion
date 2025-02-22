
using My_Shop_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel model);
        List<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(long id);
        string GetProductName(long id);
        List<ProductViewModel> List();

    }
}