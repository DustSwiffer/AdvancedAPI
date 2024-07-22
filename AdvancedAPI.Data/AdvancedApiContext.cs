using AdvancedAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAPI.Data;

/// <summary>
/// Database context.
/// </summary>
public class AdvancedApiContext : IdentityDbContext<User>
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
    /// Gender database objects.
    /// </summary>
    public DbSet<Gender> Genders { get; set; }

    /// <summary>
    /// when creating models.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        modelBuilder.Entity<User>()
            .HasOne(u => u.Gender)
            .WithMany()
            .HasForeignKey(u => u.GenderId);
        
        modelBuilder.Entity<Gender>().HasData(
            new Gender { Id = 1, Name = "Male" },
            new Gender { Id = 2, Name = "Female" },
            new Gender { Id = 3, Name = "Non-Binary" },
            new Gender { Id = 4, Name = "Other" }
        );
    }
}
