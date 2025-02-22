using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using System.Collections.Generic;

namespace My_ShopQuery.Contract.Support
{
    public interface ISupportQueryModel
    {
       SupportQueryModel GetSupportQuery();

    }
}