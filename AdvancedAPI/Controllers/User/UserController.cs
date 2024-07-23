using AdvancedAPI.BaseControllers;
using AdvancedAPI.Data.ViewModels.User;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.Controllers.User;

/// <summary>
/// User endpoints
/// </summary>
public class UserController : UserBaseController
{
    private readonly IUserService _userService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Get the user profile of the given user id.
    /// </summary>
    [HttpGet]
    [Route("profile")]
    public async Task<IActionResult> GetUserProfile(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequestResult("User id can't be empty");
        }

        UserProfileResponseModel? userProfile = await _userService.GetUserProfile(userId);

        if (userProfile == null)
        {
            return NotFound("There is no user with this userId");
        }

        return Ok(userProfile);
    }
}
