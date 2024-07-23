using AdvancedAPI.Data.ViewModels.User;

namespace Business.Services.Interfaces;

/// <summary>
/// User service.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Gets the user profile of the given user id.
    /// </summary>
    public Task<UserProfileResponseModel?> GetUserProfile(string userId);

    /// <summary>
    /// Updates the last seen state of the user.
    /// </summary>
    public Task UpdateLastSeen(string userId);
}
