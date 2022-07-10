using Microsoft.AspNetCore.Http;
using File = Domains.File;

namespace ServicesInterfaces;

public interface IFileService: IFilePathService
{
    Task<File> SaveFile(IFormFile file, int userId, CancellationToken cancellationToken);
    Task DropFile(File file, int userId, CancellationToken cancellationToken);
}