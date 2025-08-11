using CharityConnect.Application.DTOs.Notifications;

namespace CharityConnect.Application.Interfaces
{
    public interface INotificationService
    {
        Task<List<NotificationDTO>> GetUserNotificationsAsync(int userId);
        Task AddNotificationAsync(int recipientId, string message);
        Task MarkAsReadAsync(int notificationId, int userId);
    }
}
