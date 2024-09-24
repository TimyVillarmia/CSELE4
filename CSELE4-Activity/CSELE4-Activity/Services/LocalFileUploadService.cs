
using CSELE4_Activity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSELE4_Activity.Services
{

    public class LocalFileUploadService : IFileUploadService
    {

        public LocalFileUploadService(IWebHostEnvironment environment)
        {
            _webHostEnvironment = environment;
        }

        public IWebHostEnvironment _webHostEnvironment { get; }

        public async Task UploadFileAsync(IFormFile ProductImage)
        {
            var imageFile = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products", ProductImage.FileName);
            using (var fileStream = new FileStream(imageFile, FileMode.Create))
            {   
                await ProductImage.CopyToAsync(fileStream);
            }

            return;

        }
    }
}
