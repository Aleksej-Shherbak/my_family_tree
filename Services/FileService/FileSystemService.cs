using Dto.Options;
using Microsoft.Extensions.Options;
using ServicesInterfaces;

namespace Services.FileService;

public class FileSystemService: IFileSystemService
{
    private readonly FileStorageOptions _fileStorageOptions;

    public FileSystemService(IOptions<FileStorageOptions> fileStorageOptions)
    {
        _fileStorageOptions = fileStorageOptions.Value;
    }
    
    /// <summary>
    /// Returns path to user's file storage folder.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public string GetUserStoragePath(int userId)
    {
        var path = Path.Combine(_fileStorageOptions.FileStorageFolder, userId.ToString());
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;
    }

    public string? GetFileFullPath(int userId, string fileName)
    {
        var path = Path.Combine(GetUserStoragePath(userId), fileName);

        if (File.Exists(path))
        {
            return path;
        }

        return null;
    }
}