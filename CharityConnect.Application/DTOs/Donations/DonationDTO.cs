namespace CharityConnect.Application.DTOs.Donations
{
    public class DonationDTO
    {
        public decimal Amount { get; set; }
        public string TransactionId { get; set; } = null!;
    }
}
