using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AdvancedAPI.Data.Repositories;

/// <inheritdoc />
public class IdentityRepository : IIdentityRepository
{
    private readonly UserManager<User> _userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public IdentityRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    /// <inheritdoc />
    public async Task<User> GetUserByName(string userName) => await _userManager.FindByNameAsync(userName);

    /// <inheritdoc />
    public async Task<User> GetUserById(string userId) => await _userManager.FindByIdAsync(userId);

    /// <inheritdoc />
    public async Task<bool> CheckPassword(User user, string password) =>
        await _userManager.CheckPasswordAsync(user, password);

    public async Task<IList<string>> GetRoles(User user) => await _userManager.GetRolesAsync(user);
}
