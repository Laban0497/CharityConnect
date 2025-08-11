namespace CharityConnect.Application.DTOs.Mpesa
{
    public class STKPushRequestDTO
    {
        public string PhoneNumber { get; set; } = null!; // Format: 2547XXXXXXXX
        public decimal Amount { get; set; }
        public string AccountReference { get; set; } = "CharityConnect";
        public string TransactionDesc { get; set; } = "Donation Payment";
    }
}
