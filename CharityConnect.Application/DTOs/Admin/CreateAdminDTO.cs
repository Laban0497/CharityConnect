namespace CharityConnect.Application.DTOs.Admin
{
    public class CreateAdminDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string AdminType { get; set; } = "Admin"; // or "Moderator"
    }
}
