namespace WebApi.Dto;

public record UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}