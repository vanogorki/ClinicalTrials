using ClinicalTrials.Application.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalTrials.Application.Common.Attributes;

public sealed class FileValidationAttribute : TypeFilterAttribute
{
    public FileValidationAttribute(string[] allowedExtensions, int maxFileSize)
        : base(typeof(FileValidationFilter))
    {
        Arguments = [allowedExtensions, maxFileSize];
    }
}