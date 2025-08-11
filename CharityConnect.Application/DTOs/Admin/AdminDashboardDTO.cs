namespace CharityConnect.Application.DTOs.Admin
{
    public class AdminDashboardDTO
    {
        public int TotalUsers { get; set; }
        public int TotalDonations { get; set; }
        public int TotalHelpRequests { get; set; }
        public int PendingHelpRequests { get; set; }
        public int ApprovedHelpRequests { get; set; }
    }
}
