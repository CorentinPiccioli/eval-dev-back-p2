using Api.DbContext;
using Api.Repository;
using Api.Repository.Contracts;
using Api.Services;
using Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


public class Program
{
    public static void Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices((hostBuilder, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(hostBuilder.Configuration.GetConnectionString("MyConnectionString")));
                
                services.AddScoped<IEventService, EventService>();
                services.AddScoped<IEventRepository, EventRepository>();
                services.AddLogging();

            })
            .Build();
        host.Run();
    }
}

