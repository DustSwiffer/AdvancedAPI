namespace AdvancedAPI.Data.ViewModels;

/// <summary>
/// Error response model. Will be sent to the requester.
/// </summary>
public class ErrorResponseModel
{
    /// <summary>
    /// Status code of the error.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Message of the error.
    /// </summary>
    public string Message { get; set; } = string.Empty;
}
