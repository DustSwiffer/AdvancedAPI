using AdvancedAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AdvancedAPI.Data.Repositories;

/// <inheritdoc />
public class IdentityRepository : IIdentityRepository
{
    private readonly UserManager<IdentityUser> _userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public IdentityRepository(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    /// <inheritdoc />
    public async Task<IdentityUser> GetUser(string userName) => await _userManager.FindByNameAsync(userName);

    /// <inheritdoc />
    public async Task<bool> CheckPassword(IdentityUser user, string password) =>
        await _userManager.CheckPasswordAsync(user, password);
}
