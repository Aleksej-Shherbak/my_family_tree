using Microsoft.AspNetCore.Http;
using File = Domains.File;

namespace ServicesInterfaces;

public interface IFileService
{
    Task<File> SaveFile(IFormFile file, int userId, CancellationToken cancellationToken);

    string GetUserStoragePath(int userId);
    string GetFileFullPath(int userId, string fileName);
}