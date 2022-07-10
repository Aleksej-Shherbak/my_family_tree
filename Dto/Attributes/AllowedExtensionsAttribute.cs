using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dto.Attributes;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedExtensionsAttribute(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (value is IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(extension.ToLower()))
            {
                return new(GetErrorMessage());
            }
        }

        return ValidationResult.Success;
    }

    private string GetErrorMessage()
    {
        if (string.IsNullOrWhiteSpace(ErrorMessage))
        {
            return "This photo extension is not allowed!";
        }

        return ErrorMessage;
    }
}