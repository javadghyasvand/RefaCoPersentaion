using System.Collections.Generic;
using My_Shop_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string Icon { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<Product> Products { get; private set; }
        public long LanguageId { get; private set; }


        public ProductCategory(long parentId, string icon)
        {
            Icon = icon;
            Products = new List<Product>();
        }

        public ProductCategory(string name, string description, string picture, string pictureAlt
            , string pictureTitle, string keyword, string metaDescription, string slug, long languageId, string icon)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
            LanguageId = languageId;
            Icon = icon;
        }

        public void Edit(string name, string description, string picture, string pictureAlt,
            string pictureTitle, string keyword, string metaDescription, string slug, long languageId, string icon)
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            if (!string.IsNullOrWhiteSpace(icon))
                Icon = icon;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
            LanguageId = languageId;
        }
    }
}