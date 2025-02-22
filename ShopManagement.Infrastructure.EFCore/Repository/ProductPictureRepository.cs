using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;
        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                PictureString = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId,
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.ProductPictures.Include(x=>x.Product).Select(x => new ProductPictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Product = x.Product.Name,
                ProductId=x.ProductId,
                IsRemoved = x.IsRemoved
            }).ToList();
            if (searchModel != null)
            {
                if (searchModel.ProductId != 0)
                {
                    var productPictureViewModels = query.Where(x => x.ProductId == searchModel.ProductId).ToList();
                    return productPictureViewModels.OrderByDescending(x => x.Id).ToList();
                }
            }
         
            return query.OrderByDescending(x => x.Id).ToList();

        }

        public List<ProductPictureViewModel> ListBy(long id)
        {
        
            return _context.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Product = x.Product.Name,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved,
                PictureTitle = x.PictureTitle
            }).Where(x => x.ProductId == id).ToList();
        }

        public ProductPictureViewModel GetBy(long id)
        {
            return _context.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Product = x.Product.Name,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved,
                PictureTitle = x.PictureTitle
            }).SingleOrDefault(x => x.Id == id);
        }
    }
}