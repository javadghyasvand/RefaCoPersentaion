using System.Collections.Generic;
using LanguageManagement.Application.Contracts.Language;

namespace Language.Application.Contracts.Language
{
    public interface ILanguageApplication
    {
        OperationResult Create(CreateLanguage command);
        OperationResult Edit(EditLanguage command);
        EditLanguage GetDetails(long id);
        List<LanguageViewModel>List();
    }
}