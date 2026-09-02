using System.Text.Json;

namespace ApiBureau.AllApis.Console.Services;

public class DataService
{
    private readonly ICloudCallClient _cloudCallClient;
    private readonly IConfluenceClient _confluenceClient;
    private readonly ILogger<DataService> _logger;

    public DataService(ICloudCallClient cloudCallClient, IConfluenceClient confluenceClient, ILogger<DataService> logger)
    {
        _cloudCallClient = cloudCallClient;
        _confluenceClient = confluenceClient;
        _logger = logger;
    }

    public async Task GetConfluenceSpacesAsync()
    {
        var spaces = await _confluenceClient.Spaces.GetAllAsync();

        _logger.LogInformation("Spaces: {Count}", spaces.Count);

        var space = spaces.FirstOrDefault(w => w.Id == "229503");
        if (space is null)
        {
            return;
        }

        var pages = await _confluenceClient.Pages.GetAllForSpaceAsync(space.Id);

        _logger.LogInformation("Pages in {SpaceName}: {Count}", space.Name, pages.Count);
    }

    public async Task GetCloudCallAccountsAsync()
    {
        var items = await _cloudCallClient.Accounts.GetAsync();

        _logger.LogInformation("Items: {items}", items.Count);

        if (items.Count > 0)
        {
            _logger.LogInformation("Example {0}", JsonSerializer.Serialize(items[0]));
        }
    }
}