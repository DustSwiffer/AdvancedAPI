using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;

namespace AdvancedAPI.Data.Repositories;

/// <inheritdoc cref="IGenderRepository"/>
public class GenderRepository : BaseRepository<Gender>, IGenderRepository
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GenderRepository(AdvancedApiContext context)
        : base(context)
    {
    }
}
