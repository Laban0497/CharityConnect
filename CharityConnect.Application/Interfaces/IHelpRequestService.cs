using CharityConnect.Application.DTOs.Help;

namespace CharityConnect.Application.Interfaces
{
    public interface IHelpRequestService
    {
        Task CreateRequestAsync(int userId, HelpRequestDTO dto);
        Task<List<HelpRequestDTO>> GetMyRequestsAsync(int userId);
    }
}
