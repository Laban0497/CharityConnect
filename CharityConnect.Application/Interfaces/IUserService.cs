using CharityConnect.Application.DTOs.User;

namespace CharityConnect.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserProfileDTO> GetProfileAsync(int userId);
        Task<bool> UpdateProfileAsync(int userId, string fullName);
        Task<bool> ChangePasswordAsync(int userId, ChangePasswordDTO dto);
    }
}