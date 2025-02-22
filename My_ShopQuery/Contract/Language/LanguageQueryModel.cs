using System.Collections.Generic;
using My_ShopQuery.Contract.Comment;

namespace My_ShopQuery.Contract.Language
{
    public class LanguageQueryModel
    {
        public long Id { get; set; }
        public string Language { get; set; }
        public string LanguageNameShowName { get; set; }
    }
}