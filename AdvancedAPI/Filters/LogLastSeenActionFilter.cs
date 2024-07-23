using System.Security.Claims;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvancedAPI.Filters;

/// <summary>
/// Last seen action filter.
/// </summary>
public class LogLastSeenActionFilter : IAsyncActionFilter
{
    private readonly IUserService _userService;

    /// <summary>
    /// Constructor
    /// </summary>
    public LogLastSeenActionFilter(IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc/>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        ClaimsPrincipal user = context.HttpContext.User;

        if (user.Identity.IsAuthenticated)
        {
            string? userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            if (!string.IsNullOrEmpty(userId))
            {
                await _userService.UpdateLastSeen(userId);
            }
        }

        await next();
    }
}
