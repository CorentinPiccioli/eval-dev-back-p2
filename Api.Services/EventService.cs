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
    
    public async Task<IEnumerable<Event>> GetEventsAsync()
    {
        return await _eventRepository.GetEventsAsync();
    }

    public async Task UpdateEventAsync(Event eventItem)
    {
        await _eventRepository.UpdateEventAsync(eventItem);
    }
    
    public async Task DeleteEventAsync(Guid id)
    {
        await _eventRepository.DeleteEventAsync(id);
    }
}