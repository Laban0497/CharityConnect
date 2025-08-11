using Microsoft.AspNetCore.Http;

namespace CharityConnect.Application.DTOs.Uploads
{
    public class FileUploadDTO
    {
        public IFormFile File { get; set; } = null!;
    }
}
