using System.Collections.Generic;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.SocialMedia;

namespace My_ShopQuery.Query
{
    public class SocialMediaQuery:ISocialMediaQueryModel
    {
        private readonly GeneralContext _context;

        public SocialMediaQuery(GeneralContext context)
        {
            _context = context;
        }


        public List<SocialMediaQueryModel> SocialMediaList()
        {
            return  _context.SocialMedia.Select(x => new SocialMediaQueryModel
            {
                Link = x.Link,
                Icon = x.Icon,
                Title = x.Title,
            }).AsNoTracking().ToList();
        }

    }
}
