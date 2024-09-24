using Microsoft.AspNetCore.Mvc;

namespace CSELE4_Activity.Services
{
    public interface IFileUploadService
    {

        Task UploadFileAsync(IFormFile file); 
    }
}
