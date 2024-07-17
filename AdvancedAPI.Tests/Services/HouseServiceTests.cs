using AdvancedAPI.Data.ViewModels.Houses;
using AutoFixture;
using Business.Services;
using Business.Services.Interfaces;

namespace Tests.Services;

/// <summary>
/// all tests for <see cref="HouseService"/>.
/// </summary>
public class HouseServiceTests
{
    private readonly IHouseService _houseService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public HouseServiceTests()
    {
        var fixture = new Fixture();
        _houseService = fixture.Create<HouseService>();
    }

    /// <summary>
    /// Tests if <see cref="HouseService.GetAllHouses"/> returns a valid list.
    /// </summary>
    [Fact]
    public async Task GetAllHousesReturnsList()
    {
        var result = await _houseService.GetAllHouses();
        Assert.Equal(new List<HouseResponseModel>(), result);
    }
}