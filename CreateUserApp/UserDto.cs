namespace CreateUserApp;

public class UserDto
{
    public UserDto(string email, string username, string password)
    {
        Email = email;
        Username = username;
        Password = password;
    }

    public string Email { get; }
    public string Username { get; }
    public string Password { get; }
}