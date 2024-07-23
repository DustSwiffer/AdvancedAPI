using System.IdentityModel.Tokens.Jwt;
using AdvancedAPI.BaseControllers;
using AdvancedAPI.Data.ViewModels.Authentication;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.Controllers;

/// <summary>
/// Authentication endpoints.
/// </summary>
public class AuthenticationController : BaseController
{
    private readonly IAuthenticationService _authenticationService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    /// <summary>
    /// endpoint to log in.
    /// </summary>
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
    {
        JwtSecurityToken? token = await _authenticationService.Login(model);

        if (token != null)
        {
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
            });
        }

        return UnauthorizedResult(null);
    }
}
