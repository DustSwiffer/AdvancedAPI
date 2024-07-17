using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;

namespace AdvancedAPI.Data.Repositories;

/// <inheritdoc /> 
public class HouseRepository: IHouseRepository
{
    /// <inheritdoc />
    public Task<List<House>> GetAllHouses()
    {
        throw new NotImplementedException();
    }
}