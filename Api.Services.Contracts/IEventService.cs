using Api.Models;

namespace Api.Services.Contracts;

public interface IEventService
{
    public Task CreateEventAsync(Event eventItem);
    
    public Task<IEnumerable<Event>> GetEventsAsync();
    
    public Task UpdateEventAsync(Event eventItem);
    public Task DeleteEventAsync(string id);
}