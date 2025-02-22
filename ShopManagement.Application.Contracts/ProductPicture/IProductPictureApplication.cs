using System.Collections.Generic;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        OperationResult IsRemove(long id);
        OperationResult Restore(long id);
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel model);
        List<ProductPictureViewModel> ListBy(long id);
        ProductPictureViewModel GetBy(long id);

    }
}