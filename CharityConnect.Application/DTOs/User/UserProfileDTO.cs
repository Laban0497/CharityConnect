namespace CharityConnect.Application.DTOs.User
{
    public class UserProfileDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public class ChangePasswordDTO
    {
        public string CurrentPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}