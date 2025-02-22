using My_Shop_Framework.Domain;
using System.Collections.Generic;
using GeneralManagement.Application.Contracts.SiteLogo;

namespace GeneralManagement.Domain.LogoAgg
{
    public interface ISiteLogoRepository : IRepository<long, SiteLogo>
    {
        EditSiteLogo GetDetails(long id);
        List<SiteLogoViewModel> GetSiteLogoList();
        SiteLogoViewModel GetSiteLogo();
    }
}