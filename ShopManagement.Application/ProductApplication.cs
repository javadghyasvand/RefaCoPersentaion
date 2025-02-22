using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name && x.LanguageId == command.LanguageId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slug();
            var categorySlug = _productCategoryRepository.GetSlugById(command.CategoryId);
            var picturePath = $"Project//{categorySlug}\\{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, picturePath);

            var manualFile = _fileUploader.FileUpload(command.ManualFile, picturePath);
            var product = new Product(command.Name,  command.Code,command.ShortDescription,command.Description,fileName,command.PictureAlt,
                command.PictureTitle,command.Keywords,slug,command.MetaDescription,command.CategoryId,command.LanguageId, manualFile,command.StarBolt,command.CommentActive);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation =new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product != null)
            {
                var slug = command.Slug.Slug();
                var categorySlug = _productCategoryRepository.GetSlugById(command.CategoryId);
                var picturePath = $"Project//{categorySlug}\\{slug}\\";
                var fileName = _fileUploader.FileUpload(command.Picture, picturePath);
                var manualFile = _fileUploader.FileUpload(command.ManualFile, picturePath);
                product.Edit(command.Name, command.Code, command.ShortDescription, command.Description, fileName,
                    command.PictureAlt,
                    command.PictureTitle, command.Keywords, slug, command.MetaDescription, command.CategoryId,
                    command.LanguageId, manualFile,command.StarBolt,command.CommentActive);
                _productRepository.SaveChanges(); 
                return operation.Success();
            }

            return operation.Failed(ApplicationMessages.RecordNotFund);
        }


        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }



        public List<ProductViewModel> Search(ProductSearchModel model)
        {
            return _productRepository.Search(model);
        }


        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public ProductViewModel GetProduct(long id)
        {
            
            return _productRepository.GetProduct(id);
        }

        public string GetProductName(long id)
        {
            return _productRepository.GetProductName(id);
        }

        public List<ProductViewModel> List()
        {
           return  _productRepository.List();
        }
    }
}