using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using ServicesInterfaces;

namespace FileStorage.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileSystemService _fileSystemService;

    public FileController(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        // TODO get user id from JWT
        var filePath = _fileSystemService.GetFileFullPath(16, name);

        if (string.IsNullOrWhiteSpace(filePath) ||
            !new FileExtensionContentTypeProvider().TryGetContentType(filePath, out var contentType))
        {
            return NotFound();
        }
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return new FileStreamResult(fileStream, contentType);
    }
}