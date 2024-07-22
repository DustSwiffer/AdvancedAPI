using System.Globalization;
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
    private readonly ILastSeenRepository _lastSeenRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserService(
        IMapper mapper,
        IIdentityRepository identityRepository,
        IGenderRepository genderRepository,
        ILastSeenRepository lastSeenRepository)
    {
        _identityRepository = identityRepository;
        _genderRepository = genderRepository;
        _lastSeenRepository = lastSeenRepository;
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
        LastSeen? lastSeen = await _lastSeenRepository.GetByUserId(user.Id);

        responseModel.LastSeen = lastSeen != null ? lastSeen.DateTime.ToString(CultureInfo.InvariantCulture) : "unknown";
        return responseModel;
    }

    /// <inheritdoc />
    public async Task UpdateLastSeen(string userId)
    {
        IEnumerable<LastSeen> lastSeens = await _lastSeenRepository.FindAsync(e => e.UserId == userId);
        LastSeen? lastSeen = lastSeens.FirstOrDefault();

        if (lastSeen != null)
        {
            lastSeen.DateTime = DateTime.Now;
            _lastSeenRepository.Update(lastSeen);
        }
        else
        {
           await _lastSeenRepository.AddAsync(
                new LastSeen()
                {
                    UserId = userId,
                    DateTime = DateTime.Now,
                });
        }

        await _lastSeenRepository.SaveAsync();
    }
}
