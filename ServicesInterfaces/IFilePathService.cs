namespace ServicesInterfaces;

public interface IFilePathService
{
    string GetUserStoragePath(int userId);
    string? GetFileFullPath(int userId, string fileName);
}