using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace My_Shop_Framework.Application
{
    public class FileExtensionLimitedAttribute:ValidationAttribute,IClientModelValidator
    {
        private readonly string[] _validExtensions;

        public FileExtensionLimitedAttribute(string[] validExtensions)
        {
            _validExtensions = validExtensions;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;
            var fileExtension = Path.GetExtension(file.FileName);

            if (!_validExtensions.Contains(fileExtension))
                return false;
           
            return true;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-Extension", "true");
            context.Attributes.Add("data-val-ExtensionFileSize", ErrorMessage);
        }
    }
}