using System.Collections.Generic;
using GeneralManagement.Application.Contracts.GeneralSetting;
using GeneralManagement.Domain.GeneralAgg;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application
{
    public class GeneralSettingApplication: IGeneralSettingApplication
    {
        private readonly IGeneralSettingRepository _generalSettingApplication;

        public GeneralSettingApplication(IGeneralSettingRepository generalSettingApplication)
        {
            _generalSettingApplication = generalSettingApplication;
        }
        public OperationResult Create(CreateGeneralSetting command)
        {
              var operation = new OperationResult();
            
                if (_generalSettingApplication.Exists(x => x.SiteTitle == command.SiteTitle && x.LanguageId == command.LanguageId))
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                var generalSetting = new GeneralSetting(command.SiteTitle
                    , command.MetaDescription, command.MetaKeywords,
                    command.AdminEmail, command.HostingSpace, command.Address
                    , command.PostalCode, command.MapLink, command.LanguageId,command.PhoneNumbers,command.WaysLink,command.BaladLink,command.GoogleLink);
                _generalSettingApplication.Create(generalSetting);
                _generalSettingApplication.SaveChanges();
                
            return operation.Success();
        }

        public OperationResult Edit(EditGeneralSetting command)
        {
            var operation = new OperationResult();
            var generalSetting = _generalSettingApplication.Get(command.Id);
            if (generalSetting == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_generalSettingApplication.Exists(x => x.SiteTitle == command.SiteTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            generalSetting.Edit(command.SiteTitle
                , command.MetaDescription, command.MetaKeywords,
                command.AdminEmail, command.HostingSpace, command.Address
                , command.PostalCode, command.MapLink, command.LanguageId,command.PhoneNumbers,command.WaysLink,command.BaladLink,command.GoogleLink);
            _generalSettingApplication.SaveChanges();
            return operation.Success();
        }

        public EditGeneralSetting GetDetails(long id)
        {
            return _generalSettingApplication.GetDetails(id);
        }

        public List<GeneralSettingViewModel> GetList()
        {
            return _generalSettingApplication.GetToList();
        }
    }
}