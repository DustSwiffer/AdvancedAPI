using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using AdvancedAPI.Data.ViewModels.Authentication;
using Business.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services;

/// <inheritdoc />
public class AuthenticationService : IAuthenticationService
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthenticationService(IIdentityRepository identityRepository, IConfiguration configuration)
    {
        _identityRepository = identityRepository;
        _configuration = configuration;
    }

    /// <inheritdoc />
    public async Task<JwtSecurityToken?> Login(LoginRequestModel requestModel, CancellationToken ct = default)
    {
        User? user = await _identityRepository.GetUserByName(requestModel.Username);
        if (user != null && await _identityRepository.CheckPassword(user, requestModel.Password))
        {
            List<Claim> authClaims = new()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            IList<string> userRoles = await _identityRepository.GetRoles(user);
            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

        return null;
    }
}
