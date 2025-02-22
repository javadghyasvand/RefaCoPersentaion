using System.Collections.Generic;
using GeneralManagement.Application.Contracts.GeneralSetting;
using GeneralManagement.Application.Contracts.SiteLogo;
using GeneralManagement.Domain.LogoAgg;
using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.GeneralAgg
{
    public interface IGeneralSettingRepository : IRepository<long, GeneralSetting>
    {
        EditGeneralSetting GetDetails(long id);
        bool FirstGeneralSetting();
        List<GeneralSettingViewModel> GetToList();
    }
}