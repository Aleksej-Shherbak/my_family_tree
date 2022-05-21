using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Auth;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }   
    
    [Required]
    public string Password { get; set; }   
}