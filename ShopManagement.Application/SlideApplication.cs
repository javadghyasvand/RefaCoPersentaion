using System.Collections.Generic;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.Slide.Agg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {       
        private readonly ISlideRepository _slideRepository;
       private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            OperationResult operationResult = new OperationResult();
            var slide = new Slide( command.Heading, command.BtnText, command.Link, command.LanguageId, command.Text);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operationResult.Success();
        }

        public OperationResult Edit(EditSlide command)
        {
            OperationResult operationResult = new OperationResult();
            var slide = _slideRepository.Get(command.Id);
            if (slide == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFund);
            }
            slide.Edit(command.Heading, command.Text ,command.BtnText, command.Link, command.LanguageId);
            _slideRepository.SaveChanges();
            return operationResult.Success();
        }

        public OperationResult Remove(long id)
        {
            OperationResult operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFund);
            }
            slide.IsRemove();
            _slideRepository.SaveChanges();
            return operationResult.Success();
        }

        public OperationResult Restore(long id)
        {
            OperationResult operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFund);
            }
            slide.Restore();
            _slideRepository.SaveChanges();
            return operationResult.Success();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> Search(SliderSearchModel model)
        {
            return  _slideRepository.Search(model);
        }
    }
}