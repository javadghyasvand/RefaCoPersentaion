using System.Collections.Generic;
using System.Linq;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.Slide.Agg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Heading = x.Heading,
                Text = x.Text,
                Link = x.Link,
                LanguageId = x.LanguageId,
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<SlideViewModel> Search(SliderSearchModel model)
        {
            var query = _context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Heading = x.Heading,
                IsRemove = x.IsRemoved,
                LanguageId = x.LanguageId,
                CreationDate = x.CreationDateTime.ToFarsi()
            });
            if (!string.IsNullOrWhiteSpace(model.Heading))
                query = query.Where(x => x.Heading.Contains(model.Heading));
            if (model.LanguageId > 0)
                query = query.Where(x => x.LanguageId == model.LanguageId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}