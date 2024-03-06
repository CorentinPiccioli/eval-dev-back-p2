using Api.Models;
using Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.AzureFunctions;

public class UpdateEvent
{
    private readonly ILogger _logger;
    private readonly IEventService _eventService;
    
    public UpdateEvent(ILoggerFactory loggerFactory, IEventService eventService)
    {
        _logger = loggerFactory.CreateLogger<AddEvent>();
        _eventService = eventService;
    }
    
    [Function("UpdateEvent")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "event/update")]
        HttpRequestData req)
    {
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Event eventItem = JsonConvert.DeserializeObject<Event>(requestBody);
            
            await _eventService.UpdateEventAsync(eventItem);
            return new StatusCodeResult(200);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred in UpdateEvent Azure function");
            return new ObjectResult(e.Message) { StatusCode = 500 };
        }
    }
}