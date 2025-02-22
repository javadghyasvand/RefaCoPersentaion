using System.Collections.Generic;
using LanguageManagement.Application.Contracts.Language;
using LanguageManagement.Domain.Language.Agg;
using My_Shop_Framework.Application;

namespace LanguageManagement.Application
{
    public class LanguageApplication: ILanguageApplication
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageApplication(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public OperationResult Create(CreateLanguage command)
        {
            var operation = new OperationResult();
            if (_languageRepository.Exists(x => x.LanguageTitle == command.LanguageTitle))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var language = new Language(command.LanguageTitle, command.LanguageNameFa, command.LanguageNameEn, command.LanguageNameRu, command.LanguageNameAr);
            _languageRepository.Create(language);
            _languageRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditLanguage command)
        {

            var operation = new OperationResult();
            var language = _languageRepository.Get(command.Id);
            if (language == null)
                operation.Failed(ApplicationMessages.RecordNotFund);

            if (_languageRepository.Exists(x => x.LanguageTitle == command.LanguageTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (language != null) language.Edit(command.LanguageTitle, command.LanguageNameFa, command.LanguageNameEn, command.LanguageNameRu, command.LanguageNameAr);
            _languageRepository.SaveChanges();
            return operation.Success();
        }

        public EditLanguage GetDetails(long id)
        {
            return _languageRepository.GetDetails(id);
        }

        public List<LanguageViewModel> List()
        {
            return _languageRepository.List();
        }
    }
}