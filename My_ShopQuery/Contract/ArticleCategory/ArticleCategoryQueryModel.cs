using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Comment;

namespace My_ShopQuery.Contract.ArticleCategory
{
   public class ArticleCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Description { get;  set; }
        public string MetaDescription { get;  set; }
        public string CanonicalAddress { get;  set; }
        public string Slug { get;  set; }
        public string Keywords { get;  set; }
        public int ShowOrder { get;  set; }
        public long  CountArticle { get; set; }
        public long LanguageId { get; set; }
        public List<string> KeywordList { get; set; }
        public List<ArticleQueryModel> Articles { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
    }
}
