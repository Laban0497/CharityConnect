using CharityConnect.Application.DTOs.User;
using CharityConnect.Application.Interfaces;
using CharityConnect.Domain.Entities;
using CharityConnect.Infrastructure.Data;

namespace CharityConnect.Infrastructure.Services
{
    public class HelpUploadService : IHelpUploadService
    {
        private readonly AppDbContext _db;
        private readonly IFileService _fileService;

        public HelpUploadService(AppDbContext db, IFileService fileService)
        {
            _db = db;
            _fileService = fileService;
        }

        public async Task<bool> SubmitAsync(int userId, HelpRequestUploadDTO dto)
        {
            string? imageUrl = null;

            if (dto.Image != null)
                imageUrl = await _fileService.UploadAsync(dto.Image);

            var request = new HelpRequest
            {
                UserId = userId,
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow,
                Status = RequestStatus.Pending
            };

            _db.HelpRequests.Add(request);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
