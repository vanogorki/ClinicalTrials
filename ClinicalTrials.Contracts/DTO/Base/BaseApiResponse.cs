namespace ClinicalTrials.Contracts.DTO.Base;

public class BaseApiResponse(bool isSuccess = false, string? message = null, object? data = null)
{
    public static BaseApiResponse Success(string message = "Success", object? data = null)
    {
        return new BaseApiResponse(true, message, data);
    }
    
    public static BaseApiResponse Fail(string message = "Error", object? data = null)
    {
        return new BaseApiResponse(false, message, data);
    }

    public bool IsSuccess { get; set; } = isSuccess;
    public string? Message { get; set; } = message;
    public object? Data { get; set; } = data;
    public string? TraceIdentifier { get; set; }
}