using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CharityConnect.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        public FileService()
        {
            if (!Directory.Exists(_uploadFolder))
                Directory.CreateDirectory(_uploadFolder);
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine(_uploadFolder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{fileName}";
        }
    }
}
