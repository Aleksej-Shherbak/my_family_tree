using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dto.Attributes;

public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly int _maxFileSize;
    public MaxFileSizeAttribute(int maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        var file = value as IFormFile;
        if (file?.Length > _maxFileSize)
        {
            return new(GetErrorMessage());
        }

        return ValidationResult.Success;
    }

    private string GetErrorMessage()
    {
        if (string.IsNullOrWhiteSpace(ErrorMessage))
        {
            return $"Maximum allowed file size is { _maxFileSize} bytes.";
        }

        return ErrorMessage;
    }
}