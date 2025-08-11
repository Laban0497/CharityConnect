namespace CharityConnect.Application.DTOs.Help
{
    public class HelpRequestDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
