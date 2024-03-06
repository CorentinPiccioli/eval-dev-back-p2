﻿using Api.DbContext;
using Api.Models;
using Api.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class EventRepository : IEventRepository
{
    private readonly AppDbContext _appDbContext;
    
    public EventRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task CreateEventAsync(Event eventItem)
    {
        _appDbContext.Events.Add(eventItem);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Event>> GetEventsAsync()
    { 
        return await _appDbContext.Events.ToListAsync();
    }
}