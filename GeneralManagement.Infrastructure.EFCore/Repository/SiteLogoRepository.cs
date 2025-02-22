using System;
using System.Collections.Generic;
using System.Linq;
using GeneralManagement.Application.Contracts.SiteLogo;
using GeneralManagement.Domain.LogoAgg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Infrastructure;

namespace GeneralManagement.Infrastructure.EFCore.Repository
{
    public class SiteLogoRepository : RepositoryBase<long, SiteLogo>, ISiteLogoRepository
    {
        private readonly GeneralContext _generalContext;

        public SiteLogoRepository(GeneralContext generalContext) : base(generalContext)
        {
            _generalContext = generalContext;
        }

        public EditSiteLogo GetDetails(long id)
        {
            return _generalContext.SiteLogos.Select(x => new EditSiteLogo
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Link = x.Link,
                PictureString = x.Picture,
                LanguageId = x.LanguageId
            }).SingleOrDefault(x=>x.Id==id);
        }


        public List<SiteLogoViewModel> GetSiteLogoList()
        {
            return _generalContext.SiteLogos.Select(x => new SiteLogoViewModel()
            {
                Id = x.Id, Picture = x.Picture,Title = x.Title,Link = x.Link,PictureAlt = x.PictureAlt,PictureTitle = x.PictureTitle
            }).ToList();
        }

        public SiteLogoViewModel GetSiteLogo()
        {

            return _generalContext.SiteLogos.Select(x => new SiteLogoViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                Title = x.Title,
            }).First();
        }
    }
}