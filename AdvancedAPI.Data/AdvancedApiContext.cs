using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAPI.Data;

/// <summary>
/// Database context.
/// </summary>
public class AdvancedApiContext : IdentityDbContext<IdentityUser>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AdvancedApiContext(DbContextOptions<AdvancedApiContext> options)
        : base(options)
    {
    }
}
