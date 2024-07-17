using AdvancedAPI.Data.ViewModels.Houses;

namespace Business.Services.Interfaces;

/// <summary>
/// Service providing methods for houses.
/// </summary>
public interface IHouseService
{
    /// <summary>
    /// Obtaining List of all  houses
    /// </summary>
    public Task<List<HouseResponseModel>?> GetAllHouses(CancellationToken ct = default);
}