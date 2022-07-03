using Domains;
using EntityFramework;
using Microsoft.AspNetCore.Http;
using ServicesInterfaces;
using File = Domains.File;

namespace Services.FileService;

public class FileService : IFileService
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
        return await SaveFileInternal(formFile, userId, cancellationToken);
    }

    public async Task<File> SaveImage(IFormFile file, int userId, CancellationToken cancellationToken)
    {
        return await SaveFileInternal(file, userId, cancellationToken, isImage: true);
    }

    public string GetUserStoragePath(int userId)
    {
        return _fileSystemService.GetUserStoragePath(userId);
    }

    public string? GetFileFullPath(int userId, string fileName)
    {
        return _fileSystemService.GetFileFullPath(userId, fileName);
    }

    private async Task<File> SaveFileInternal(IFormFile formFile, int userId, CancellationToken cancellationToken,
        bool isImage = false)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
        var filePath = Path.Combine(GetUserStoragePath(userId), fileName);
        await using var stream = System.IO.File.Create(filePath);
        await formFile.CopyToAsync(stream, cancellationToken);
        var file = new File
        {
            Name = fileName
        };
        
        if (isImage)
        {
            var image = new Image
            {
                Name = fileName,
                // TODO change it with real preview name when ffmpeg is done
                PreviewName = fileName
            };
            
            // TODO use ffmpeg to mack a thumbnail here
            await _dbContext.Images.AddAsync(image, cancellationToken);
            file = image;
        }
        else
        {
            await _dbContext.Files.AddAsync(file, cancellationToken);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return file;
    }
}