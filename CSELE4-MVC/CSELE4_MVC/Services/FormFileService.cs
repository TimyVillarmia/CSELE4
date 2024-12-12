
using CSELE4_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CSELE4_MVC.Services
{
    public class FormFileService : IFormFileService
    {
        public byte[] ConvertToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                     
                    return memoryStream.ToArray();
                }
                else
                {
                    throw new ArgumentException("The file is too large.");
                }

                
            }
        }
    }
}
