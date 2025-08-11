using Microsoft.AspNetCore.Http;

public class HelpRequestUploadDTO
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile? Image { get; set; }
}
