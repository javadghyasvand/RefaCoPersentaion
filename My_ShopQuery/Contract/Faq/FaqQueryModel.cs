using System.Collections.Generic;
using My_ShopQuery.Contract.Comment;

namespace My_ShopQuery.Contract.Faq
{
    public class FaqQueryModel
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public long LanguageId { get; set; }
        public bool IsRemoved { get; set; }
    }
}