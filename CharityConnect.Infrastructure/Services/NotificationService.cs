using CharityConnect.Application.DTOs.Notifications;
using CharityConnect.Application.Interfaces;
using CharityConnect.Domain.Entities;
using CharityConnect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CharityConnect.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _db;

        public NotificationService(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddNotificationAsync(int recipientId, string message)
        {
            var notification = new Notification
            {
                RecipientId = recipientId,
                Message = message
            };

            _db.Notifications.Add(notification);
            await _db.SaveChangesAsync();
        }

        public async Task<List<NotificationDTO>> GetUserNotificationsAsync(int userId)
        {
            return await _db.Notifications
                .Where(n => n.RecipientId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationDTO
                {
                    Id = n.Id,
                    Message = n.Message,
                    CreatedAt = n.CreatedAt,
                    IsRead = n.IsRead
                })
                .ToListAsync();
        }

        public async Task MarkAsReadAsync(int notificationId, int userId)
        {
            var notif = await _db.Notifications
                .FirstOrDefaultAsync(n => n.Id == notificationId && n.RecipientId == userId);

            if (notif != null)
            {
                notif.IsRead = true;
                await _db.SaveChangesAsync();
            }
        }
    }
}
