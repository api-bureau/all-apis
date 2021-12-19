var services = new ServiceCollection();

var startup = new Startup();

startup.ConfigureServices(services);

var serviceProvider = services.BuildServiceProvider();

var dataService = serviceProvider.GetService<DataService>()
    ?? throw new ArgumentNullException($"{nameof(DataService)} cannot be null");


await dataService.GetStatusAsync();
await dataService.GetConfluneceSpacesAsync();