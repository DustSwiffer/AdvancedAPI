using AdvancedAPI.Data.ViewModels.Houses;
using Business.Services.Interfaces;

namespace Business.Services;

/// <inheritdoc />
public class HouseService: IHouseService
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public HouseService()
    {
    }

    /// <inheritdoc />
    public Task<List<HouseResponseModel>> GetAllHouses(CancellationToken cancellationToken)
    {
        return Task.FromResult(new List<HouseResponseModel>());
    }
}