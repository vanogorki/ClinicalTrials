using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ClinicalTrials.Application.Attributes;

public sealed class MaxFileSizeAttribute(int maxFileSize) : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            if (file.Length > maxFileSize)
            {
                return new ValidationResult($"Maximum allowed file size is {maxFileSize / (1024 * 1024)} MB.");
            }
        }

        return ValidationResult.Success!;
    }
}