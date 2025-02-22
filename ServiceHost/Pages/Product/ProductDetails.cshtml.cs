using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Product;
using My_ShopQuery.Contract.ProductCategory;
using My_ShopQuery.Contract.SocialMedia;

namespace ServiceHost.Pages.Product
{
    public class ProductDetails : PageModel
    {
        public ProductQueryModel ProductQueryModel;
        public List<ProductCategoryQueryModel> ProductCategoryQuery;
        public List<SocialMediaQueryModel> SocialMediaQueryModels;
        public List<ProductQueryModel> ListProductQueryModels;
        private readonly IProductQueryModel _productQueryModel;
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly ISocialMediaQueryModel _socialMediaQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductDetails(IProductQueryModel productQueryModel, ICommentApplication commentApplication, IProductCategoryQuery productCategoryQuery, ISocialMediaQueryModel socialMediaQuery)
        {
            _productQueryModel = productQueryModel;
            _commentApplication = commentApplication;
            _productCategoryQuery = productCategoryQuery;
            _socialMediaQuery = socialMediaQuery;
        }

        public void OnGet(string slug)
        {
            ProductQueryModel = _productQueryModel.GetProductDetails(slug);
            ProductCategoryQuery = _productCategoryQuery.GetProductCategories();
            SocialMediaQueryModels = _socialMediaQuery.SocialMediaList();
        }

        public IActionResult OnPost(CreateComment commend, string productSlug)
        {
            commend.Type = CommentType.Product;
            var result = _commentApplication.CreateComment(commend);
            return Redirect($"/ProductDetails/{productSlug}");
        }
    }
}
