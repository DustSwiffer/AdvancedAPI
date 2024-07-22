using System.IdentityModel.Tokens.Jwt;
using AdvancedAPI.Data.ViewModels.Authentication;

namespace Business.Services.Interfaces;

/// <summary>
/// Authentication service.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Logs in the user and returns a token.
    /// </summary>
    public Task<JwtSecurityToken?> Login(LoginRequestModel requestModel, CancellationToken ct = default);
}
