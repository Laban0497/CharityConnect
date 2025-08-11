namespace CharityConnect.Domain.Entities
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class HelpRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Needy user
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }
    }
}
