using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;

namespace AdvancedAPI.Data.Repositories;

/// <inheritdoc cref="IHouseRepository" />
public class HouseRepository : BaseRepository<House>, IHouseRepository
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public HouseRepository(AdvancedApiContext context)
        : base(context)
    {
    }
}
