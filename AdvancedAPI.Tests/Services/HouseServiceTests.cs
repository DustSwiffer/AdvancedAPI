using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using AdvancedAPI.Data.ViewModels.Houses;
using AutoFixture;
using Business.Services;
using Business.Services.Interfaces;
using Moq;

namespace Tests.Services;

/// <summary>
/// all tests for <see cref="HouseService"/>.
/// </summary>
public class HouseServiceTests
{
    private readonly IHouseService _houseService;
    private readonly Mock<IHouseRepository> _houseRepository;
    /// <summary>
    /// Constructor.
    /// </summary>
    public HouseServiceTests()
    {
        var fixture = new Fixture();
        _houseRepository = fixture.Freeze<Mock<IHouseRepository>>();
        _houseService = new HouseService(_houseRepository.Object);
    }

    /// <summary>
    /// Tests if <see cref="HouseService.GetAllHouses"/> returns a valid list.
    /// </summary>
    [Fact]
    public async Task GetAllHousesReturnsNull()
    {
        _houseRepository.Setup(x => x.GetAllHouses()).ReturnsAsync(new List<House>());
        var result = await _houseService.GetAllHouses();
        Assert.Equal(null, result);
    }
    
    /// <summary>
    /// Tests if <see cref="HouseService.GetAllHouses"/> returns a valid list.
    /// </summary>
    [Fact]
    public async Task GetAllHousesReturnsList()
    {
        _houseRepository.Setup(x => x.GetAllHouses()).ReturnsAsync(new List<House>{new()});
        var result = await _houseService.GetAllHouses();
        Assert.Equal(new List<HouseResponseModel>(), result);
    }
}