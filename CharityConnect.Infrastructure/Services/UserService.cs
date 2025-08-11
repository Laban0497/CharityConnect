using CharityConnect.Application.DTOs.User;
using CharityConnect.Application.Interfaces;
using CharityConnect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CharityConnect.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserProfileDTO> GetProfileAsync(int userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null) throw new Exception("User not found");

            return new UserProfileDTO
            {
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        public async Task<bool> UpdateProfileAsync(int userId, string fullName)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null) return false;

            user.FullName = fullName;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDTO dto)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null) return false;

            if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.PasswordHash))
                return false;

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}