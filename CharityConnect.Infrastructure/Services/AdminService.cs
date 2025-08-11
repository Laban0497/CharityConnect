using CharityConnect.Application.DTOs.Admin;
using CharityConnect.Application.Interfaces;
using CharityConnect.Domain.Entities;
using CharityConnect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CharityConnect.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _db;

        public AdminService(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAdminAsync(CreateAdminDTO dto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = UserRole.Admin,
                AdminType = dto.AdminType
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<List<CreateAdminDTO>> GetAdminsAsync()
        {
            return await _db.Users
                .Where(u => u.Role == UserRole.Admin)
                .Select(u => new CreateAdminDTO
                {
                    FullName = u.FullName,
                    Email = u.Email,
                    AdminType = u.AdminType!
                }).ToListAsync();
        }

        public async Task<bool> DeleteAdminAsync(int id)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Id == id && u.Role == UserRole.Admin);

            if (user == null)
                return false;

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
