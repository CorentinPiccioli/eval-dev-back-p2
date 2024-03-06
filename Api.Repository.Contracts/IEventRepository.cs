using Api.Models;

namespace Api.Repository.Contracts;

public interface IEventRepository
{
    public Task CreateEventAsync(Event eventItem);
}