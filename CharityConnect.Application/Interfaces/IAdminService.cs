using CharityConnect.Application.DTOs.Admin;

namespace CharityConnect.Application.Interfaces
{
    public interface IAdminService
    {
        Task AddAdminAsync(CreateAdminDTO dto);
        Task<List<CreateAdminDTO>> GetAdminsAsync();
        Task<bool> DeleteAdminAsync(int id); 
    }
}
