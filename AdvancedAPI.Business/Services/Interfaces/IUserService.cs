using AdvancedAPI.Data.ViewModels.User;

namespace Business.Services.Interfaces;

public interface IUserService
{
    public Task<UserProfileResponseModel?> GetUserProfile(string userId);
}