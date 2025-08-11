namespace CharityConnect.MVC.Models
{
    public class DonationViewModel
    {
        public string DonorName { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string RecipientName { get; set; } = null!;
    }
}
