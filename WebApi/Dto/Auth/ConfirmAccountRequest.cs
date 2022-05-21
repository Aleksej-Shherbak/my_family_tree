using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Auth;

public class ConfirmAccountRequest
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string Code { get; set; }
}