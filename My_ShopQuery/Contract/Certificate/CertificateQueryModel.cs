using System.Collections.Generic;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Comment;

namespace My_ShopQuery.Contract.Certificate
{
   public class CertificateQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string IconString { get; set; }
        public string ImageString { get; set; }
        public string Description { get; set; }
        public long LanguageId { get; set; }
        public string Pdf { get; set; }
    }
}
