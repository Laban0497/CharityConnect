using Microsoft.AspNetCore.Http;

namespace CharityConnect.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
