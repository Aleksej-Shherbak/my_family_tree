using EntityFramework;
using Microsoft.AspNetCore.Http;
using ServicesInterfaces;
using File = Domains.File;

namespace Services.FileService;

public class FileService: IFileService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IFileSystemService _fileSystemService;

    public FileService(ApplicationDbContext dbContext, IFileSystemService fileSystemService)
    {
        _dbContext = dbContext;
        _fileSystemService = fileSystemService;
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
        return _fileSystemService.GetUserStoragePath(userId);
    }

    public string? GetFileFullPath(int userId, string fileName)
    {
        return _fileSystemService.GetFileFullPath(userId, fileName);
    }
}