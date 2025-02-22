
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string FileUpload(IFormFile file, string path)
        {
            if (file == null) return "";
            var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", path);
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(directoryPath, fileName);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            try
            {
                using var output = System.IO.File.Create(filePath);
                file.CopyTo(output);
            }
            catch (Exception ex)
            {
                // مدیریت خطا، می‌توانید لاگ یا پیام خطا اضافه کنید
                throw new Exception("Error saving the file", ex);
            }

            return Path.Combine(path, fileName);

            //
            // if (file == null) return "";
            //
            // var directoryPath = $"{_webHostEnvironment.WebRootPath}\\Images\\{path}";
            // var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            // var filePath = $"{directoryPath}\\{fileName}";
            //
            // if (!System.IO.Directory.Exists(directoryPath)) System.IO.Directory.CreateDirectory(directoryPath);
            // using var output = System.IO.File.Create(filePath);
            // file.CopyTo(output);
            // return $"{path}{fileName}";
        } 
    }
}