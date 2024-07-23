using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAPI.Data.Repositories;

/// <inheritdoc cref="ILastSeenRepository"/>
public class LastSeenRepository : BaseRepository<LastSeen>, ILastSeenRepository
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public LastSeenRepository(AdvancedApiContext context)
        : base(context)
    {
    }

    /// <inheritdoc cref="ILastSeenRepository"/>
    public async Task<LastSeen?> GetByUserId(string userId) => await _context.LastSeens.FirstOrDefaultAsync(ls => ls.UserId == userId);
}
