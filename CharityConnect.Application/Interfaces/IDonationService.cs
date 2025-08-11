using CharityConnect.Application.DTOs.Donations;

namespace CharityConnect.Application.Interfaces
{
    public interface IDonationService
    {
        Task SubmitDonationAsync(int donorId, DonationDTO dto);
        Task<List<DonationDTO>> GetAllAsync(); // for admins
    }
}
