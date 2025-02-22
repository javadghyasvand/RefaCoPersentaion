
using System.Collections.Generic;
using LanguageManagement.Application.Contracts.Language;
using My_Shop_Framework.Domain;

namespace LanguageManagement.Domain.Language.Agg
{
    public interface ILanguageRepository : IRepository<long,Language>
    {
        EditLanguage GetDetails(long id);
        List<LanguageViewModel> List();

    }
}