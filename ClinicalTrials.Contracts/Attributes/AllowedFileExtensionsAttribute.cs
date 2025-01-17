using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ClinicalTrials.Contracts.Attributes;

public class AllowedFileExtensionsAttribute(string[] extensions) : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is IFormFile file) return IsExtensionAllowed(file);

        return ValidationResult.Success!;
    }

    private ValidationResult IsExtensionAllowed(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName);
        var isSuccess = extensions.Contains(extension.ToLower());
        var wrongExtensionMessage = GetErrorMessage(extension);

        return isSuccess
            ? ValidationResult.Success!
            : new ValidationResult(wrongExtensionMessage);
    }

    private static string GetErrorMessage(string fileExtension)
    {
        return $"File extension {fileExtension} is not allowed!";
    }
}