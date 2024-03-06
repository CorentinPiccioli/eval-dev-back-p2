using Api.Models;
using Api.Repository.Contracts;
using Api.Services.Contracts;

namespace Api.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    
    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public async Task CreateEventAsync(Event eventItem)
    {
        await _eventRepository.CreateEventAsync(eventItem);
    }
}