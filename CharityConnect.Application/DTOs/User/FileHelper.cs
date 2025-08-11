using Microsoft.AspNetCore.Http;

public class FileHelper
{
    public static async Task<string?> SaveFileAsync(IFormFile file, string folder)
    {
        var ext = Path.GetExtension(file.FileName);
        var name = $"{Guid.NewGuid()}{ext}";
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder, name);

        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"/{folder}/{name}";
    }
}
