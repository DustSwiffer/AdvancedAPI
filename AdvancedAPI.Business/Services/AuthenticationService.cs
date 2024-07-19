using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AdvancedAPI.Data.Repositories.Interfaces;
using AdvancedAPI.Data.ViewModels.Authentication;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        IdentityUser? user = await _identityRepository.GetUser(requestModel.Username);
        if (user != null && await _identityRepository.CheckPassword(user, requestModel.Password))
        {
            Claim[] authClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

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
