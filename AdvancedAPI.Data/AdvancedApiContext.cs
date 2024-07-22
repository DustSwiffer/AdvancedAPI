using AdvancedAPI.Data.Models;
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

    /// <summary>
    /// News article database objects.
    /// </summary>
    public DbSet<NewsArticle> NewsArticles { get; set; }
    
    /// <summary>
    /// when creating models.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ensure primary keys are defined for IdentityUserLogin
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        // Additional model configurations
    }
}
