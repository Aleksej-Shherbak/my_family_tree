namespace ServicesInterfaces;

public interface IFileSystemService
{
    string GetUserStoragePath(int userId);
    string? GetFileFullPath(int userId, string fileName);
}