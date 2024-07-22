using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using AdvancedAPI.Data.ViewModels.User;
using AutoMapper;
using Business.Services.Interfaces;

namespace Business.Services;

/// <inheritdoc />
public class UserService : IUserService
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserService(IMapper mapper, IIdentityRepository identityRepository, IGenderRepository genderRepository)
    {
        _identityRepository = identityRepository;
        _genderRepository = genderRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<UserProfileResponseModel?> GetUserProfile(string userId)
    {
        User? user = await _identityRepository.GetUserById(userId);

        if (user == null)
        {
            return null;
        }

        user.Gender = await _genderRepository.GetByIdAsync(user.GenderId);

        UserProfileResponseModel responseModel = _mapper.Map<UserProfileResponseModel>(user);

        responseModel.Birthday = user.DateOfBirth.ToString("MMMM d");
        return responseModel;
    }
}
