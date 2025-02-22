using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Product;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.Slide;

namespace My_ShopQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;
        private readonly LanguageContext _langContext;
        public SlideQuery(ShopContext shopContext, LanguageContext langContext)
        {
            _shopContext = shopContext;
            _langContext = langContext;
        }

        public List<SlideQueryModel> GetSlidesList()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var LanguageId = _langContext.Languages.FirstOrDefault(x => x.LanguageTitle == currentLanguage).Id;
            return _shopContext.Slides.Where(x => x.IsRemoved == false).Select(x => new SlideQueryModel
            {
                BtnText = x.BtnText,
                Heading = x.Heading,
                Link = x.Link,
                Text = x.Text,
                LanguageId = x.LanguageId
            }).AsNoTracking().Where(x=>x.LanguageId== LanguageId).ToList();
        }
    }
}