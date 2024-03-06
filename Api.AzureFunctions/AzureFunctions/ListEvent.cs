using Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.AzureFunctions;

public class ListEvent
{
    private readonly ILogger _logger;
    private readonly IEventService _eventService;
    
    public ListEvent(ILoggerFactory loggerFactory, IEventService eventService)
    {
        _logger = loggerFactory.CreateLogger<AddEvent>();
        _eventService = eventService;
    }
    
    [Function("ListEvent")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "event/list")]
        HttpRequestData req)
    {
        try
        {
            var events = await _eventService.GetEventsAsync();
            return new OkObjectResult(events);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred in ListEvent Azure function");
            return new ObjectResult(e.Message) { StatusCode = 500 };
        }
    }
}