using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Comment;
using My_ShopQuery.Contract.SocialMedia;

namespace ServiceHost.Pages.Article
{
    public class ArticleDetailsModel : PageModel
    {

        public ArticleQueryModel ArticleQueryModel;
        public List<ArticleQueryModel> ArticleQueryModelList;
        public List<SocialMediaQueryModel> SocialMediaQueryModels;
        private readonly IArticleQueryModel _articleQueryModel;
        private readonly ICommentQueryModel _commentQueryModel;
        private readonly ICommentApplication _commentApplication;
        private readonly ISocialMediaQueryModel _socialMediaQueryModel;


        public ArticleDetailsModel(IArticleQueryModel articleQueryModel, ISocialMediaQueryModel socialMediaQueryModel, ICommentQueryModel commentQueryModel, ICommentApplication commentApplication)
        {
            _articleQueryModel = articleQueryModel;
            _socialMediaQueryModel = socialMediaQueryModel;
            _commentQueryModel = commentQueryModel;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            ArticleQueryModel = _articleQueryModel.GetDetailsBy(id);
            ArticleQueryModel.Comments = _commentQueryModel.GetCommentQuery(ArticleQueryModel.Id);
            ArticleQueryModelList = _articleQueryModel.LatestArticles();
            SocialMediaQueryModels = _socialMediaQueryModel.SocialMediaList();
        }

        public IActionResult OnPost(CreateComment commend, string articleSlug)
        {
            commend.Type = CommentType.Article;
            var result = _commentApplication.CreateComment(commend);
            return Redirect($"/ArticleDetails/{articleSlug}");
        }

    }

}
