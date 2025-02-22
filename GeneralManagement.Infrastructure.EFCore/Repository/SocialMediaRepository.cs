using System.Collections.Generic;
using System.Linq;
using GeneralManagement.Application.Contracts.SocialMedia;
using GeneralManagement.Domain.SocialMediaAgg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Infrastructure;
using ISocialMediaRepository = GeneralManagement.Domain.SocialMediaAgg.ISocialMediaRepository;

namespace GeneralManagement.Infrastructure.EFCore.Repository
{
    public class SocialMediaRepository:RepositoryBase<long,SocialMedia>,ISocialMediaRepository
    {
        private  readonly  GeneralContext _generalContext;
        public SocialMediaRepository(GeneralContext generalContext) : base(generalContext)
        {
            _generalContext = generalContext;
        }

        public EditSocialMedia GetDetails(long id)
        {
            return _generalContext.SocialMedia.Select(x => new EditSocialMedia()
            {
                Id = x.Id,
                IconString = x.Icon,
                Link = x.Link,
                Title = x.Title,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SocialMediaViewModel> List()
        {
            return _generalContext.SocialMedia.Select(x => new SocialMediaViewModel()
            {
                Icon = x.Icon,
                Link = x.Link,
                Title = x.Title,
                Id = x.Id
            }).ToList();
        }
    }
}