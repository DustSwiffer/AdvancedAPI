using AdvancedAPI.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(
        (context, services) =>
        {
            services.AddHostedService<Worker>();
        })
    .Build();

await host.RunAsync();
