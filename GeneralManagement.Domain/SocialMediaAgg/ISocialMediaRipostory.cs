using My_Shop_Framework.Domain;
using System.Collections.Generic;
using GeneralManagement.Application.Contracts.SocialMedia;

namespace GeneralManagement.Domain.SocialMediaAgg
{
    public interface ISocialMediaRepository : IRepository<long, SocialMedia>
    {
        EditSocialMedia GetDetails(long id);
        List<SocialMediaViewModel> List();
    }
}