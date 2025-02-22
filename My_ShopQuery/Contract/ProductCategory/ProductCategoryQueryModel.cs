using System.Collections.Generic;
using My_ShopQuery.Contract.Product;

namespace My_ShopQuery.Contract.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string Picture { get; set; }
        public string Icon { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public long LanguageId { get; set; }

        public List<ProductQueryModel> Products { get; set; }
    }
}
