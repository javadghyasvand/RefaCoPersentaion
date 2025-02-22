using System.Collections.Generic;
using GeneralManagement.Application.Contracts.SiteLogo;
using GeneralManagement.Domain.LogoAgg;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application
{
    public class SiteLogoApplication: ISiteLogoApplication
    {
        private readonly ISiteLogoRepository _siteLogoRepository;
        private readonly IFileUploader _fileUploader;

        public SiteLogoApplication(ISiteLogoRepository siteLogoRepository, IFileUploader fileUploader)
        {
            _siteLogoRepository = siteLogoRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSiteLogo command)
        {
            var operation = new OperationResult();
            
                if (_siteLogoRepository.Exists(x => x.Title == command.Title && x.LanguageId == command.LanguageId))
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                var path = $"Logo\\{command.Title.Slug()}\\";
                var fileName = _fileUploader.FileUpload(command.Picture, path);

                var siteLogo = new SiteLogo(command.Title, fileName
                    , command.PictureAlt, command.PictureTitle, command.Link,command.LanguageId);
                _siteLogoRepository.Create(siteLogo);
                _siteLogoRepository.SaveChanges();
                
            return operation.Success();

        }

        public OperationResult Edit(EditSiteLogo command)
        {
            var operation = new OperationResult();
            var siteLogo = _siteLogoRepository.Get(command.Id);
            if (siteLogo == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            var path = $"Logo\\{command.Title.Slug()}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, path);
            siteLogo.Edit(command.Title, fileName
                , command.PictureAlt, command.PictureTitle, command.Link,command.LanguageId);
            _siteLogoRepository.SaveChanges();
            return operation.Success();
        }

        public List<SiteLogoViewModel> GetSiteLogoList()
        {
            return _siteLogoRepository.GetSiteLogoList();
        }

        public SiteLogoViewModel GetSiteLogo()
        {
            return _siteLogoRepository.GetSiteLogo();
        }

        public EditSiteLogo GetDetails(long id)
        {
            return _siteLogoRepository.GetDetails(id);
        }

    }
}