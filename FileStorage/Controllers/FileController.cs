using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using ServicesInterfaces;

namespace FileStorage.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IFilePathService _filePathService;
    private int UserId => HttpContext.User.GetLoggedInUserId<int>();
    public FileController(IFilePathService filePathService)
    {
        _filePathService = filePathService;
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        var filePath = _filePathService.GetFileFullPath(UserId, name);

        if (string.IsNullOrWhiteSpace(filePath) ||
            !new FileExtensionContentTypeProvider().TryGetContentType(filePath, out var contentType))
        {
            return NotFound();
        }
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return new FileStreamResult(fileStream, contentType);
    }
}