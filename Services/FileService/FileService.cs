using EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ServicesInterfaces;
using File = Domains.File;

namespace Services.FileService;

public class FileService: IFileService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly FileStorageOptions _fileStorageOptions;

    public FileService(IOptions<FileStorageOptions> fileStorageOptions, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _fileStorageOptions = fileStorageOptions.Value;
    }
    
    public async Task<File> SaveFile(IFormFile formFile, int userId, CancellationToken cancellationToken)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
        var filePath = Path.Combine(GetUserStoragePath(userId), fileName);
        await using var stream = System.IO.File.Create(filePath);
        await formFile.CopyToAsync(stream, cancellationToken);
        var file = new File
        {
            Name = fileName
        };

        await _dbContext.Files.AddAsync(file, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return file;
    }

    public string GetUserStoragePath(int userId)
    {
        var path = Path.Combine(_fileStorageOptions.FileStorageFolder, userId.ToString());
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;
    }

    public string GetFileFullPath(int userId, string fileName)
    {
        return Path.Combine(GetUserStoragePath(userId), fileName);
    }
}