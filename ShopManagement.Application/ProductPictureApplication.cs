using System.Collections.Generic;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using My_Shop_Framework.Application;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            if (command.ProductId > 0)
            {
                var product = _productRepository.GetDetails(command.ProductId);
                var categorySlug = _productCategoryRepository.GetDetails(product.CategoryId).Slug;
                var path = $"Project\\{categorySlug}\\{product.Slug}\\";
                var picture = _fileUploader.FileUpload(command.Picture, path);
                var productPicture = new ProductPicture(command.ProductId, picture, command.PictureAlt,
                    command.PictureTitle);
                _productPictureRepository.Create(productPicture);
                _productPictureRepository.SaveChanges();
                return operation.Success();
            }
            return operation.Failed("مجددا تلاش نمایید");

        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(command.Id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            var product = _productRepository.GetDetails(command.ProductId);
            var categorySlug = _productCategoryRepository.GetDetails(product.CategoryId).Slug;
            var path = $"Project//{categorySlug}\\{product.Slug}\\";
            var picture = _fileUploader.FileUpload(command.Picture, path);


            productPicture.Edit(command.ProductId, picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return operation.Success();

        }

        public OperationResult IsRemove(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            productPicture.Remove();
            _productPictureRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.Success();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel model)
        {
            return _productPictureRepository.Search(model);
        }

        public List<ProductPictureViewModel> ListBy(long id)
        {
            return _productPictureRepository.ListBy(id);
        }

        public ProductPictureViewModel GetBy(long id)
        {
            return _productPictureRepository.GetBy(id);
        }
    }
}