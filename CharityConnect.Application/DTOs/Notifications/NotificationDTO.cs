namespace CharityConnect.Application.DTOs.Notifications
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
