namespace CharityConnect.MVC.Models
{
    public class NotificationViewModel
    {
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; } = string.Empty; // Optional: if your backend filters by role
    }
}
