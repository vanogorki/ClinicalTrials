using ClinicalTrials.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalTrials.API.Attributes;

public sealed class FileValidationAttribute : TypeFilterAttribute
{
    public FileValidationAttribute(string[] allowedExtensions, int maxFileSize)
        : base(typeof(FileValidationFilter))
    {
        Arguments = [allowedExtensions, maxFileSize];
    }
}