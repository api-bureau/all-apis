var hostBuilder = Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddCloudCall(context.Configuration);
            services.AddConfluence(context.Configuration);
            services.AddScoped<DataService>();
        }).Build();

var serviceScopeFactory = hostBuilder.Services.GetService<IServiceScopeFactory>();

using var scope = serviceScopeFactory?.CreateScope();

var service = scope?.ServiceProvider.GetService<DataService>();

if (service == null) return;

await service.GetCloudCallAccuontsAsync();
//await dataService.GetConfluneceSpacesAsync();
