using System.ComponentModel;
using System.Diagnostics;
using Domains;
using EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ServicesInterfaces;
using File = Domains.File;

namespace Services.FileService;

public class FileService : IFileService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IFileSystemService _fileSystemService;
    private readonly ILogger<FileService> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(
        ApplicationDbContext dbContext, 
        IFileSystemService fileSystemService,
        ILogger<FileService> logger,
        IWebHostEnvironment webHostEnvironment
        ) 
    {
        _dbContext = dbContext;
        _fileSystemService = fileSystemService;
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
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
        await using (var stream = System.IO.File.Create(filePath))
        {
            await formFile.CopyToAsync(stream, cancellationToken);
        }

        var file = new File
        {
            Name = fileName
        };

        if (isImage)
        {
            var previewImageFileName = await MakePreviewImage(userId, fileName, cancellationToken);
            var image = new Image
            {
                Name = fileName,
                PreviewName = previewImageFileName
            };

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