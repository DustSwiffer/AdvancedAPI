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
    Task<IdentityUser> GetUser(string userName);

    /// <summary>
    /// Checks the password of the user with user manager.
    /// </summary>
    Task<bool> CheckPassword(IdentityUser user, string password);
}
