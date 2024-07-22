using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AdvancedAPI.Data
{
    /// <summary>
    /// Factory for creating <see cref="AdvancedApiContext"/> instances at design time for EF Core tooling.
    /// </summary>
    public class AdvancedApiContextFactory : IDesignTimeDbContextFactory<AdvancedApiContext>
    {
        /// <summary>
        /// Creates a new <see cref="AdvancedApiContext"/> with design-time configuration.
        /// </summary>
        public AdvancedApiContext CreateDbContext(string[] args)
        {
            IConfigurationRoot? configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<AdvancedApiContext> optionsBuilder = new DbContextOptionsBuilder<AdvancedApiContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new AdvancedApiContext(optionsBuilder.Options);
        }
    }
}