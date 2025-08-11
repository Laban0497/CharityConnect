using CharityConnect.Application.DTOs.Help;
using CharityConnect.Application.Interfaces;
using CharityConnect.Domain.Entities;
using CharityConnect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CharityConnect.Application.Services
{
    public class HelpRequestService : IHelpRequestService
    {
        private readonly AppDbContext _db;

        public HelpRequestService(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateRequestAsync(int userId, HelpRequestDTO dto)
        {
            var request = new HelpRequest
            {
                UserId = userId,
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Status = RequestStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _db.HelpRequests.Add(request);
            await _db.SaveChangesAsync();
        }

        public async Task<List<HelpRequestDTO>> GetMyRequestsAsync(int userId)
        {
            return await _db.HelpRequests
                .Where(r => r.UserId == userId)
                .Select(r => new HelpRequestDTO
                {
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl
                })
                .ToListAsync();
        }
    }
}
