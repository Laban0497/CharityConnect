namespace CharityConnect.Domain.Entities
{
    public class Donation
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; } = null!;
        public DateTime DonatedAt { get; set; } = DateTime.UtcNow;

        public User? Donor { get; set; }
    }
}
