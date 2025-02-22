using System.Collections.Generic;
using GeneralManagement.Application.Contracts.SocialMedia;
using GeneralManagement.Domain.SocialMediaAgg;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application
{
    public class SocialMediaApplication:ISocialMediaApplication
    {
        private  readonly  ISocialMediaRepository _socialMediaRepository;
        private  readonly  IFileUploader _fileUploader;

        public SocialMediaApplication(ISocialMediaRepository socialMediaRepository, IFileUploader fileUploader)
        {
            _socialMediaRepository = socialMediaRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSocialMedia command)
        {
            var operation = new OperationResult();
           
                if (_socialMediaRepository.Exists(x => x.Title == command.Title))
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                var path = $"Social\\{command.Title.Slug()}\\";
                var fileName = _fileUploader.FileUpload(command.Icon, path);

                var socialMedia = new SocialMedia(command.Title, fileName,command.Link);
                _socialMediaRepository.Create(socialMedia);
                _socialMediaRepository.SaveChanges();
                return operation.Success();
        }

        public OperationResult Edit(EditSocialMedia command)
        {
            var operation = new OperationResult();
            var socialMedia = _socialMediaRepository.Get(command.Id);
            if (socialMedia == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_socialMediaRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var path = $"Social\\{command.Title.Slug()}\\";
            var fileName = _fileUploader.FileUpload(command.Icon, path);
            socialMedia.Edit(command.Title, fileName, command.Link);
            _socialMediaRepository.SaveChanges();
            return operation.Success();
        }

        public EditSocialMedia GetDetails(long id)
        {
            return _socialMediaRepository.GetDetails(id);
        }

        public List<SocialMediaViewModel> ListSocial()
        {
            return _socialMediaRepository.List();
        }
    }
}