using CharityConnect.Application.DTOs.Admin;
using CharityConnect.Application.Interfaces;
using CharityConnect.Domain.Entities;
using CharityConnect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CharityConnect.Infrastructure.Services
{
    public class AdminReportService : IAdminReportService
    {
        private readonly AppDbContext _db;

        public AdminReportService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<AdminDashboardDTO> GetDashboardAsync()
        {
            return new AdminDashboardDTO
            {
                TotalUsers = await _db.Users.CountAsync(),
                TotalDonations = await _db.Donations.CountAsync(),
                TotalHelpRequests = await _db.HelpRequests.CountAsync(),
                PendingHelpRequests = await _db.HelpRequests.CountAsync(r => r.Status == RequestStatus.Pending),
                ApprovedHelpRequests = await _db.HelpRequests.CountAsync(r => r.Status == RequestStatus.Approved)

            };
        }
    }
}
