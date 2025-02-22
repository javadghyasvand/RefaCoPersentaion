using My_Shop_Framework.Application;
using System.Collections.Generic;

namespace LanguageManagement.Application.Contracts.Language
{
    public interface ILanguageApplication
    {
        OperationResult Create(CreateLanguage command);
        OperationResult Edit(EditLanguage command);
        EditLanguage GetDetails(long id);
        List<LanguageViewModel>List();
    }
}