using Microsoft.AspNetCore.Http;

namespace CharityConnect.MVC.Models
{
    public class HelpRequestViewModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IFormFile? Image { get; set; }
    }

    public class HelpRequestResponse
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public bool IsApproved { get; set; }
    }
}
