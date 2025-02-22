using System.Collections.Generic;
using My_Shop_Framework.Domain;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository:IRepository<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        List<ProductPictureViewModel> ListBy(long id);
        ProductPictureViewModel GetBy(long id);
    }
}