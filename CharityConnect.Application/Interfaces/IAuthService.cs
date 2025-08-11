using CharityConnect.Application.DTOs.Auth;



namespace CharityConnect.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDTO dto);
        Task<string> LoginAsync(LoginDTO dto);
    }
}
