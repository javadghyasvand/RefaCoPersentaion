using System.Collections.Generic;
using My_ShopQuery.Contract.Galley;

namespace My_ShopQuery.Contract.Galley
{
    public interface IGalleryQueryModel
    {
        List<GalleryQueryModel> GetAll();
    }
}