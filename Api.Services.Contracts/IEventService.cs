using Api.Models;

namespace Api.Services.Contracts;

public interface IEventService
{
    public Task CreateEventAsync(Event eventItem);
}