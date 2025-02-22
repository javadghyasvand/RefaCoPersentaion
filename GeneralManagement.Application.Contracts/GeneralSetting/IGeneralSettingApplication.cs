using System.Collections.Generic;
using GeneralManagement.Application.Contracts.SiteLogo;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.GeneralSetting
{
    public interface IGeneralSettingApplication
    {
        OperationResult Create(CreateGeneralSetting command);
        OperationResult Edit(EditGeneralSetting command);
        EditGeneralSetting GetDetails(long id);
        List<GeneralSettingViewModel> GetList();

    }
}