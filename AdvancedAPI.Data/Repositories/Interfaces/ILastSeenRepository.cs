using AdvancedAPI.Data.Models;

namespace AdvancedAPI.Data.Repositories.Interfaces;

/// <summary>
/// LastSeen Repository.
/// </summary>
public interface ILastSeenRepository : IBaseRepository<LastSeen>
{
    /// <summary>
    /// Getting single object of Last seen by user id.
    /// </summary>
    public Task<LastSeen?> GetByUserId(string userId);
}
