using AdvancedAPI.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.BaseControllers;

/// <summary>
/// Base controller.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public BaseController()
    {
    }

    /// <summary>
    /// Returns an error when user is sending invalid request data.
    /// </summary>
    protected BadRequestObjectResult BadRequestResult(string? message)
    {
        return BadRequest(
            new ErrorResponseModel
            {
                Code = 400,
                Message = !string.IsNullOrEmpty(message) ? message : "The data you sent to the endpoint is invalid.",
            });
    }

    /// <summary>
    /// Returns an error when user is not authorized.
    /// </summary>
    protected UnauthorizedObjectResult UnauthorizedResult(string? message)
    {
        return Unauthorized(
            new ErrorResponseModel
            {
                Code = 401,
                Message = !string.IsNullOrEmpty(message) ? message : "You are not authorized for this request.",
            });
    }

    /// <summary>
    /// Returns an error when object is not found.
    /// </summary>
    protected NotFoundObjectResult NotFoundResult(string? message)
    {
        return NotFound(
            new ErrorResponseModel
            {
                Code = 404,
                Message = !string.IsNullOrEmpty(message) ? message : "Could not find any result",
            });
    }
}
