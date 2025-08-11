namespace CharityConnect.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int RecipientId { get; set; }     // User to be notified
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
