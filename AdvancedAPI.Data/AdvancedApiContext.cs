using AdvancedAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAPI.Data;

/// <summary>
/// Database context.
/// </summary>
public class AdvancedApiContext : DbContext
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AdvancedApiContext(DbContextOptions<AdvancedApiContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// DbSet of <see cref="House"/>.
    /// </summary>
    public DbSet<House> Houses { get; set; }
}
