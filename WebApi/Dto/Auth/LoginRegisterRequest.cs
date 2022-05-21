using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Auth;

public class LoginRegisterRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }   
    
    [Required]
    public string Password { get; set; }   
}