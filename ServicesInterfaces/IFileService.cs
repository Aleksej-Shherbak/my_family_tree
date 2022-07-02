using Microsoft.AspNetCore.Http;
using File = Domains.File;

namespace ServicesInterfaces;

public interface IFileService: IFileSystemService
{
    Task<File> SaveFile(IFormFile file, int userId, CancellationToken cancellationToken);
}