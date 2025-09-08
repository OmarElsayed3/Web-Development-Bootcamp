using AuthTask1.Services.Interfaces.IEmailService;
using AuthTask1.Settings;

namespace AuthTask1.Services.Implementations;

public class FileService(ServerSetting serverSetting) : IFileService
{
    private readonly string _mainDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
    
    public string? GetFilePath(string? filePath)
    {
        return string.IsNullOrEmpty(filePath) ? null : Path.Combine(_mainDirectory, filePath);
    }
}