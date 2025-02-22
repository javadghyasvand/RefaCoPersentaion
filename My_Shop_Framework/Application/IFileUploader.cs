using Microsoft.AspNetCore.Http;

namespace My_Shop_Framework.Application
{
    public interface IFileUploader
    {
        string FileUpload(IFormFile file,string picturePath);
    }
}