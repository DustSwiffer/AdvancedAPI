using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using AdvancedAPI.Data.ViewModels.Houses;
using Business.Services.Interfaces;

namespace Business.Services;

/// <inheritdoc />
public class HouseService: IHouseService
{

    private readonly IHouseRepository _houseRepository;
    /// <summary>
    /// Constructor.
    /// </summary>
    public HouseService(IHouseRepository houseRepository)
    {
        _houseRepository = houseRepository;
    }

    /// <inheritdoc />
    public async Task<List<HouseResponseModel>?> GetAllHouses(CancellationToken cancellationToken)
    {
        List<House> houses = await _houseRepository.GetAllHouses();

        if (!houses.Any())
        {
            return null;
        }

        return new List<HouseResponseModel>();
    }
}