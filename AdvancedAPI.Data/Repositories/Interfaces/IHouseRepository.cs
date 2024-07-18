using AdvancedAPI.Data.Models;

namespace AdvancedAPI.Data.Repositories.Interfaces;

/// <summary>
/// <see cref="House"/> Repository to provide data from the database.
/// </summary>
public interface IHouseRepository
{
    /// <summary>
    /// obtaining a List of <see cref="House"/>.
    /// </summary>
    public Task<List<House>> GetAllHouses();
}
