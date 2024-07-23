using System.Globalization;
using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using AdvancedAPI.Data.ViewModels.User;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Business.Services;
using Business.Services.Interfaces;
using Moq;

namespace Tests.Services;

/// <summary>
/// Tests of the user service.
/// </summary>
public class UserServiceTests
{
    private readonly IFixture _fixture;
    private readonly IUserService _UserService;
    private readonly Mock<IIdentityRepository> _identityRepository;
    private readonly Mock<IGenderRepository> _genderRepository;
    private readonly Mock<ILastSeenRepository> _lastSeenRepository;
    private readonly Mock<IMapper> _mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _identityRepository = _fixture.Freeze<Mock<IIdentityRepository>>();
        _genderRepository = _fixture.Freeze<Mock<IGenderRepository>>();
        _lastSeenRepository = _fixture.Freeze<Mock<ILastSeenRepository>>();
        _mapper = _fixture.Freeze<Mock<IMapper>>();
        _UserService = new UserService(
            _mapper.Object,
            _identityRepository.Object,
            _genderRepository.Object,
            _lastSeenRepository.Object);
    }

    /// <summary>
    /// Tests if GetUserProfile returns null when there is an invalid userid given.
    /// </summary>
    [Fact]
    public async Task GetUserProfileReturnsNullOnWrongUserId()
    {
        string userId = "invalid-user-id";
        _identityRepository.Setup(ir => ir.GetUserById(It.IsAny<string>())).ReturnsAsync((User?)null);

        UserProfileResponseModel? response = await _UserService.GetUserProfile(userId);

        Assert.Null(response);
    }

    /// <summary>
    /// Tests if GetUserProfile returns a profile with last seen set to unknown.
    /// </summary>
    [Fact]
    public async Task GetUserProfileReturnsSuccessfullyWithUnknownLastSeen()
    {
        string userId = "valid-user-id";
        User userResult = new User
        {
            UserName = "unittest@test.dev",
            Email = "unittest@test.dev",
            DisplayName = "Unit test user",
            DateOfBirth = new DateTime(2024, 7, 23),
            Gender = new Gender
            {
                Id = 1,
                Name = "Robot",
            },
        };
        Gender genderResult = new Gender
        {
            Id = 1,
            Name = "Robot",
        };

        _identityRepository.Setup(ir => ir.GetUserById(It.IsAny<string>())).ReturnsAsync(userResult);
        _genderRepository.Setup(gr => gr.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(genderResult);
        _lastSeenRepository.Setup(lsr => lsr.GetByUserId(It.IsAny<string>())).ReturnsAsync((LastSeen?)null);
        UserProfileResponseModel? response = await _UserService.GetUserProfile(userId);

        Assert.Equal("unknown", response.LastSeen);
    }

    /// <summary>
    /// Tests if GetUserProfile returns a profile with a filled last seen.
    /// </summary>
    [Fact]
    public async Task GetUserProfileReturnsSuccessfullyWithFilledLastSeen()
    {
        string userId = "valid-user-id";
        User userResult = new User
        {
            UserName = "unittest@test.dev",
            Email = "unittest@test.dev",
            DisplayName = "Unit test user",
            DateOfBirth = new DateTime(2024, 7, 23),
            Gender = new Gender
            {
                Id = 1,
                Name = "Robot",
            },
        };

        LastSeen lastSeenResult = new LastSeen
        {
            Id = 1,
            UserId = userId,
            DateTime = DateTime.Now,
        };

        Gender genderResult = new Gender
        {
            Id = 1,
            Name = "Robot",
        };

        _identityRepository.Setup(ir => ir.GetUserById(It.IsAny<string>())).ReturnsAsync(userResult);
        _genderRepository.Setup(gr => gr.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(genderResult);
        _lastSeenRepository.Setup(lsr => lsr.GetByUserId(It.IsAny<string>())).ReturnsAsync(lastSeenResult);
        UserProfileResponseModel? response = await _UserService.GetUserProfile(userId);

        Assert.Equal(lastSeenResult.DateTime.ToString(CultureInfo.InvariantCulture), response.LastSeen);
    }
}
