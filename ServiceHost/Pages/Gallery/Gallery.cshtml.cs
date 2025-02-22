using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Galley;

namespace ServiceHost.Pages.Gallery
{
    public class GalleryModel : PageModel
    {
        private  readonly  IGalleryQueryModel _galleryQueryModel;
        public List<GalleryQueryModel> Gallery;
        public GalleryModel(IGalleryQueryModel galleryQueryModel)
        {
            _galleryQueryModel = galleryQueryModel;
        }

        public void OnGet()
        {
            Gallery =_galleryQueryModel.GetAll();
        }
    }
}
