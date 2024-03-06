using Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.AzureFunctions;

public class DeleteEvent
{
    private readonly ILogger _logger;
    private readonly IEventService _eventService;
    
    public DeleteEvent(ILoggerFactory loggerFactory, IEventService eventService)
    {
        _logger = loggerFactory.CreateLogger<AddEvent>();
        _eventService = eventService;
    }
    
    [Function("DeleteEvent")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "event/delete/{id}")]
        HttpRequestData req,
        string id)
    {
        try
        {
            await _eventService.DeleteEventAsync(id);
            return new StatusCodeResult(200);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred in DeleteEvent Azure function");
            return new ObjectResult(e.Message) { StatusCode = 500 };
        }
    }
}