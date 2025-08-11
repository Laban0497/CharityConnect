using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityConnect.Domain.Entities
{
    public enum UserRole { Donor, Needy, Admin, Moderator, SuperAdmin }

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; }
        public string? AdminType { get; set; }  // only for Admins
    }
}