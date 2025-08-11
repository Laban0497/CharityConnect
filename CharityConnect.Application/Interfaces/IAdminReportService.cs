using CharityConnect.Application.DTOs.Admin;

namespace CharityConnect.Application.Interfaces
{
    public interface IAdminReportService
    {
        Task<AdminDashboardDTO> GetDashboardAsync();
    }
}
