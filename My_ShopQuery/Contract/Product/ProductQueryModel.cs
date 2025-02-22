using System;
using System.Collections.Generic;
using My_ShopQuery.Contract.Comment;

namespace My_ShopQuery.Contract.Product
{
    public class ProductQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public double DoublePrice { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public int DiscountRate { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public string Slug { get; set; }
        public bool HasDiscount { get; set; }
        public string DiscountExpireDate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string CategorySlug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public bool InStock { get; set; }
        public long LanguageId { get; set; }
        public long ShopType { get; set; }
        public string StarBolt { get; set; }
        public string Manual { get; set; }
        public bool CommentActive { get; set; }
        
        public List<ProductPictureQueryModal> Pictures { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
        public List<ProductQueryModel> ProductList { get; set; }
        public List<string> KeywordList { get; set; }
    }

    public class ProductPictureQueryModal
    {
        public long ProductId { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public bool IsRemoved { get; set; }
    }
}