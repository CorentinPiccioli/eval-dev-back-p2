using Api.Models;
using Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.AzureFunctions
{
    /// <summary>
    /// Azure Function pour mettre à jour un événement.
    /// </summary>
    public class UpdateEvent
    {
        private readonly ILogger _logger;
        private readonly IEventService _eventService;
        
        /// <summary>
        /// Constructeur de la classe UpdateEvent.
        /// </summary>
        /// <param name="loggerFactory">Factory pour créer des instances de ILogger.</param>
        /// <param name="eventService">Service pour gérer les événements.</param>
        public UpdateEvent(ILoggerFactory loggerFactory, IEventService eventService)
        {
            _logger = loggerFactory.CreateLogger<AddEvent>();
            _eventService = eventService;
        }
        
        /// <summary>
        /// Méthode exécutant la mise à jour d'un événement.
        /// </summary>
        /// <param name="req">Requête HTTP.</param>
        /// <returns>Résultat de l'opération.</returns>
        [Function("UpdateEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "event/update")]
            HttpRequestData req)
        {
            try
            {
                // Lecture du corps de la requête pour obtenir les données de l'événement
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Event eventItem = JsonConvert.DeserializeObject<Event>(requestBody);
                
                // Appel à la méthode de service pour mettre à jour l'événement
                await _eventService.UpdateEventAsync(eventItem);
                return new StatusCodeResult(200); // Retourne un code 200 (OK) si la mise à jour réussit
            }
            catch (Exception e)
            {
                // En cas d'erreur, journalise l'exception
                _logger.LogError(e, "An error occurred in UpdateEvent Azure function");
                return new ObjectResult(e.Message) { StatusCode = 500 }; // Retourne un code 500 (Internal Server Error) avec le message d'erreur
            }
        }
    }
}
