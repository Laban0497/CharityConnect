namespace CharityConnect.Application.DTOs.Payments
{
    public class StkPushRequestDTO
    {
        public string PhoneNumber { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
