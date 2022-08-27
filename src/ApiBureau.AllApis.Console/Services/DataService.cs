using System.Text.Json;

namespace ApiBureau.AllApis.Console.Services;

public class DataService
{
    private readonly CloudCallClient _cloudCallClient;
    private readonly ConfluenceClient _confluenceClient;
    private readonly ILogger<DataService> _logger;

    public DataService(CloudCallClient cloudCallClient, ConfluenceClient confluenceClient, ILogger<DataService> logger)
    {
        _cloudCallClient = cloudCallClient;
        _confluenceClient = confluenceClient;
        _logger = logger;
    }

    public async Task GetConfluneceSpacesAsync()
    {
        //var dto = await _confluenceClient.GetContentAsync(0);

        //_logger.LogInformation(dto?.Body.View.Value);

        var spaceResultDto = await _confluenceClient.Spaces.GetAsync();

        _logger.LogInformation($"Items: {spaceResultDto.Results.Count}");

        var expand = new SpaceExpand().AddBody().AddVersion().AddAncestors().AddChildren();

        var spacePagesResultDto = await _confluenceClient.Spaces.GetContentAsync("", expand);

        _logger.LogInformation($"Items: {spacePagesResultDto.Count}");
    }

    public async Task GetCloudCallAccuontsAsync()
    {
        var items = await _cloudCallClient.Accounts.GetAsync();

        _logger.LogInformation("Items: {items}", items.Count);

        if (items.Count > 0)
        {
            _logger.LogInformation("Example {0}", JsonSerializer.Serialize(items[0]));
        }
    }
}