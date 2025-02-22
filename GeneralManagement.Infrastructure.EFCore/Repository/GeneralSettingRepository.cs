using System.Collections.Generic;
using GeneralManagement.Application.Contracts.GeneralSetting;
using GeneralManagement.Domain.GeneralAgg;
using My_Shop_Framework.Infrastructure;
using System.Linq;
using System;

namespace GeneralManagement.Infrastructure.EFCore.Repository
{
    public class GeneralSettingRepository : RepositoryBase<long, GeneralSetting>, IGeneralSettingRepository
    {
        private readonly GeneralContext _generalContext;

        public GeneralSettingRepository(GeneralContext generalContext) : base(generalContext)
        {
            _generalContext = generalContext;
        }

        public EditGeneralSetting GetDetails(long id)
        {
            return _generalContext.GeneralSettings.Select(x => new EditGeneralSetting
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                MetaDescription = x.MetaDescription,
                Address = x.Address,
                AdminEmail = x.AdminEmail,
                HostingSpace = x.HostingSpace,
                MapLink = x.MapLink,
                MetaKeywords = x.MetaKeywords,
                PostalCode = x.PostalCode,
                SiteTitle = x.SiteTitle,
                PhoneNumbers = x.PhoneNumbers,
                BaladLink = x.BaladLink,
                WaysLink = x.WaysLink,
                GoogleLink = x.GoogleLink
            }).FirstOrDefault(x=>x.Id== id);
        }

        public bool FirstGeneralSetting()
        {
            var any = _generalContext.SiteLogos.Any();
            return any;
        }

        public List<GeneralSettingViewModel> GetToList()
        {
            var query = _generalContext.GeneralSettings.Select(x => new GeneralSettingViewModel
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                MetaDescription = x.MetaDescription,
                Address = x.Address,
                AdminEmail = x.AdminEmail,
                HostingSpace = x.HostingSpace,
                MapLink = x.MapLink,
                MetaKeywords = x.MetaKeywords,
                PostalCode = x.PostalCode,
                SiteTitle = x.SiteTitle,
                PhoneNumbers = x.PhoneNumbers,
                BaladLink = x.BaladLink,
                WaysLink = x.WaysLink,
                GoogleLink = x.GoogleLink
            });
            return query.ToList();
        }
    }
}