using Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.AzureFunctions
{
    /// <summary>
    /// Azure Function pour supprimer un événement.
    /// </summary>
    public class DeleteEvent
    {
        private readonly ILogger _logger;
        private readonly IEventService _eventService;
        
        /// <summary>
        /// Constructeur de la classe DeleteEvent.
        /// </summary>
        /// <param name="loggerFactory">Factory pour créer des instances de ILogger.</param>
        /// <param name="eventService">Service pour gérer les événements.</param>
        public DeleteEvent(ILoggerFactory loggerFactory, IEventService eventService)
        {
            _logger = loggerFactory.CreateLogger<AddEvent>();
            _eventService = eventService;
        }
        
        /// <summary>
        /// Méthode exécutant la suppression d'un événement.
        /// </summary>
        /// <param name="req">Requête HTTP.</param>
        /// <param name="id">ID de l'événement à supprimer.</param>
        /// <returns>Résultat de l'opération.</returns>
        [Function("DeleteEvent")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "event/delete/{id}")]
            HttpRequestData req,
            Guid id)
        {
            try
            {
                // Appel à la méthode de service pour supprimer l'événement
                await _eventService.DeleteEventAsync(id);
                return new StatusCodeResult(200); // Retourne un code 200 (OK) si la suppression réussit
            }
            catch (Exception e)
            {
                // En cas d'erreur, journalise l'exception
                _logger.LogError(e, "An error occurred in DeleteEvent Azure function");
                return new ObjectResult(e.Message) { StatusCode = 500 }; // Retourne un code 500 (Internal Server Error) avec le message d'erreur
            }
        }
    }
}
