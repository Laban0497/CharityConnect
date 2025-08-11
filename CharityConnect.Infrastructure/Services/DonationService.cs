using CharityConnect.Application.DTOs.Donations;
using CharityConnect.Application.Interfaces;
using CharityConnect.Domain.Entities;
using CharityConnect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CharityConnect.Application.Services
{
    public class DonationService : IDonationService
    {
        private readonly AppDbContext _db;

        public DonationService(AppDbContext db)
        {
            _db = db;
        }

        public async Task SubmitDonationAsync(int donorId, DonationDTO dto)
        {
            var donation = new Donation
            {
                DonorId = donorId,
                Amount = dto.Amount,
                TransactionId = dto.TransactionId,
                DonatedAt = DateTime.UtcNow
            };

            _db.Donations.Add(donation);
            await _db.SaveChangesAsync();
        }

        public async Task<List<DonationDTO>> GetAllAsync()
        {
            return await _db.Donations
                .Select(d => new DonationDTO
                {
                    Amount = d.Amount,
                    TransactionId = d.TransactionId
                }).ToListAsync();
        }
    }
}
