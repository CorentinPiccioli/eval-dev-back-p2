using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Event> Events { get; set; }
}