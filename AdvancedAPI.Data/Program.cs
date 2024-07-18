using AdvancedAPI.Data;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(
        (context, services) =>
        {
            var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

            // Register ApplicationDbContext with the connection string
            services.AddDbContext<AdvancedApiContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddHostedService<Worker>();
        })
    .Build();

await host.RunAsync();
