using System.ComponentModel;
using System.Diagnostics;
using Domains;
using EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ServicesInterfaces;
using File = Domains.File;

namespace Services.FileServices;

public class FileService : IFileService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IFilePathService _filePathService;
    private readonly ILogger<FileService> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string[] _allowedImages = new[] { ".jpg", ".png", ".jpeg" };

    public FileService(
        ApplicationDbContext dbContext, 
        IFilePathService filePathService,
        ILogger<FileService> logger,
        IWebHostEnvironment webHostEnvironment
        ) 
    {
        _dbContext = dbContext;
        _filePathService = filePathService;
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }
    
    public async Task<File> SaveFile(IFormFile formFile, int userId, CancellationToken cancellationToken)
    {
        var fileExtension = Path.GetExtension(formFile.FileName);
        var fileName = $"{Guid.NewGuid()}{fileExtension}";
        var filePath = Path.Combine(GetUserStoragePath(userId), fileName);
        await using (var stream = System.IO.File.Create(filePath))
        {
            await formFile.CopyToAsync(stream, cancellationToken);
        }
        
        if (_allowedImages.Contains(fileExtension))
        {
            var previewImageFileName = await MakePreviewImage(userId, fileName, cancellationToken);
            var image = new Image
            {
                Name = fileName,
                PreviewName = previewImageFileName
            };

            await _dbContext.Images.AddAsync(image, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return image;
        }

        var file = new File
        {
            Name = fileName
        };
        
        await _dbContext.Files.AddAsync(file, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return file;
    }

    public async Task DropFile(File file, int userId, CancellationToken cancellationToken)
    {
        DeleteFileIfExists(file.Name, userId);

        if (file is Image image)
        {
            DeleteFileIfExists(image.PreviewName, userId);
            _dbContext.Images.Remove(image);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
        
        _dbContext.Files.Remove(file);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public string GetUserStoragePath(int userId)
    {
        return _filePathService.GetUserStoragePath(userId);
    }

    public string? GetFileFullPath(int userId, string fileName)
    {
        return _filePathService.GetFileFullPath(userId, fileName);
    }

    private void DeleteFileIfExists(string name, int userId)
    {
        var filePath = _filePathService.GetFileFullPath(userId, name);
        if (string.IsNullOrWhiteSpace(filePath))
        {
            return;
        }
        System.IO.File.Delete(filePath);
    }

    private string FfmpegPath => Path.Combine(_webHostEnvironment.ContentRootPath, "Ffmpeg", "ffmpeg.exe");

    private async Task<string> MakePreviewImage(int userId, string fileName, CancellationToken cancellationToken)
    {
        var inputFilePath = GetFileFullPath(userId, fileName);
        
        var outputFileName = $"preview_{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";
        var outputFilePath = Path.Combine(GetUserStoragePath(userId), outputFileName);
        try
        {
            if (!System.IO.File.Exists(inputFilePath))
            {
                throw new InvalidEnumArgumentException($"File not found. File path: {inputFilePath}");
            }
            
            var startInfo = new ProcessStartInfo
            {
                FileName = FfmpegPath,
                Arguments =
                    $"-i {inputFilePath} -vf scale=320:240 {outputFilePath}",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            using var process = new Process { StartInfo = startInfo };
            process.Start();
            await process.WaitForExitAsync(cancellationToken);

            if (!System.IO.File.Exists(outputFilePath))
            {
                throw new Exception(
                    $"FFMPEG failed to generate preview image. Input path {inputFilePath}, output path: {outputFilePath}");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Preview image processing failed. Input file: {0}", fileName);
        }

        return outputFileName;
    }
}