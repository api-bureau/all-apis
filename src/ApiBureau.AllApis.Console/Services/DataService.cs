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

        var spaceResultDto = await _confluenceClient.GetSpaceAsync();

        _logger.LogInformation($"Items: {spaceResultDto.Results.Count}");

        var expand = new SpaceExpand().AddBody().AddVersion().AddAncestors().AddChildren();

        var spacePagesResultDto = await _confluenceClient.GetSpaceContentAsync("", expand);

        _logger.LogInformation($"Items: {spacePagesResultDto.Count}");
    }

    public async Task GetStatusAsync()
    {
        //var dto = await _cloudCallClient.Skills.GetStatusAsync();

        //if (dto.IsSuccess)
        //{
        //    var status = dto.Data!;

        //    _logger.LogInformation(status.Healthy.ToString());
        //    _logger.LogInformation(status.Message);
        //}
    }
}

