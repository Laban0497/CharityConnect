using CharityConnect.Application.DTOs.User;

namespace CharityConnect.Application.Interfaces
{
    public interface IHelpUploadService
    {
        Task<bool> SubmitAsync(int userId, HelpRequestUploadDTO dto);
    }
}
