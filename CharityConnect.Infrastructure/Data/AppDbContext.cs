using CharityConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityConnect.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<HelpRequest> HelpRequests => Set<HelpRequest>();
        public DbSet<Donation> Donations => Set<Donation>();
        public DbSet<Notification> Notifications { get; set; }



    }
}
