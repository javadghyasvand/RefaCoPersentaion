using System.Collections.Generic;
using GeneralManagement.Application.Contracts.GeneralSetting;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.SiteLogo
{
    public interface ISiteLogoApplication
    {
        OperationResult Create(CreateSiteLogo command);
        OperationResult Edit(EditSiteLogo command);
        List<SiteLogoViewModel> GetSiteLogoList();
        SiteLogoViewModel GetSiteLogo();
        EditSiteLogo GetDetails(long id);

    }
}