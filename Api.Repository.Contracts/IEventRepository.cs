using Api.Models;

namespace Api.Repository.Contracts;

public interface IEventRepository
{
    public Task CreateEventAsync(Event eventItem);
    
    public Task<IEnumerable<Event>> GetEventsAsync();
    
    public Task UpdateEventAsync(Event eventItem);
    
    public Task DeleteEventAsync(string id);
}