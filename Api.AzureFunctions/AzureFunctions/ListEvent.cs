using Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.AzureFunctions
{
    /// <summary>
    /// Azure Function pour lister les événements.
    /// </summary>
    public class ListEvent
    {
        private readonly ILogger _logger;
        private readonly IEventService _eventService;
        
        /// <summary>
        /// Constructeur de la classe ListEvent.
        /// </summary>
        /// <param name="loggerFactory">Factory pour créer des instances de ILogger.</param>
        /// <param name="eventService">Service pour gérer les événements.</param>
        public ListEvent(ILoggerFactory loggerFactory, IEventService eventService)
        {
            _logger = loggerFactory.CreateLogger<AddEvent>();
            _eventService = eventService;
        }
        
        /// <summary>
        /// Méthode exécutant la récupération de la liste des événements.
        /// </summary>
        /// <param name="req">Requête HTTP.</param>
        /// <returns>Résultat de l'opération.</returns>
        [Function("ListEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "event/list")]
            HttpRequestData req)
        {
            try
            {
                // Appel à la méthode de service pour obtenir la liste des événements
                var events = await _eventService.GetEventsAsync();
                return new OkObjectResult(events); // Retourne la liste des événements avec un code 200 (OK)
            }
            catch (Exception e)
            {
                // En cas d'erreur, journalise l'exception
                _logger.LogError(e, "An error occurred in ListEvent Azure function");
                return new ObjectResult(e.Message) { StatusCode = 500 }; // Retourne un code 500 (Internal Server Error) avec le message d'erreur
            }
        }
    }
}
