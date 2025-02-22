using GeneralManagement.Application.Contracts.GeneralSetting;
using My_Shop_Framework.Application;
using System.Collections.Generic;

namespace GeneralManagement.Application.Contracts.SocialMedia
{
    public interface ISocialMediaApplication
    {
        OperationResult Create(CreateSocialMedia command);
        OperationResult Edit(EditSocialMedia command);
        EditSocialMedia GetDetails(long id);
        List<SocialMediaViewModel> ListSocial();
    }
}