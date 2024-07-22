using Microsoft.AspNetCore.Identity;

namespace AdvancedAPI.Data.Repositories.Interfaces;

/// <summary>
/// Identity repository.
/// </summary>
public interface IIdentityRepository
{
    /// <summary>
    /// Getting the user from User manager.
    /// </summary>
    public Task<IdentityUser> GetUser(string userName);

    /// <summary>
    /// Checks the password of the user with user manager.
    /// </summary>
    public Task<bool> CheckPassword(IdentityUser user, string password);

    /// <summary>
    /// Getting a list of roles assigned to the user.
    /// </summary>
    public Task<IList<string>> GetRoles(IdentityUser user);
}
