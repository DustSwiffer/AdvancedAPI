using AdvancedAPI.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AdvancedAPI.Data.Repositories.Interfaces;

/// <summary>
/// Identity repository.
/// </summary>
public interface IIdentityRepository
{
    /// <summary>
    /// Getting the user from User manager by name.
    /// </summary>
    public Task<User> GetUserByName(string userName);

    /// <summary>
    /// Getting user from user manager by id.
    /// </summary>
    public Task<User?> GetUserById(string userId);

    /// <summary>
    /// Checks the password of the user with user manager.
    /// </summary>
    public Task<bool> CheckPassword(User user, string password);

    /// <summary>
    /// Getting a list of roles assigned to the user.
    /// </summary>
    public Task<IList<string>> GetRoles(User user);
}
