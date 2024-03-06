using Api.Models;

namespace Api.Repository.Contracts
{
    /// <summary>
    /// Interface pour définir les opérations de base sur les événements dans le référentiel.
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// Crée un nouvel événement.
        /// </summary>
        /// <param name="eventItem">Événement à créer.</param>
        /// <returns>Tâche asynchrone.</returns>
        public Task CreateEventAsync(Event eventItem);
        
        /// <summary>
        /// Récupère la liste des événements.
        /// </summary>
        /// <returns>Liste des événements.</returns>
        public Task<IEnumerable<Event>> GetEventsAsync();
        
        /// <summary>
        /// Met à jour un événement existant.
        /// </summary>
        /// <param name="eventItem">Événement à mettre à jour.</param>
        /// <returns>Tâche asynchrone.</returns>
        public Task UpdateEventAsync(Event eventItem);
        
        /// <summary>
        /// Supprime un événement en fonction de son ID.
        /// </summary>
        /// <param name="id">ID de l'événement à supprimer.</param>
        /// <returns>Tâche asynchrone.</returns>
        public Task DeleteEventAsync(string id);
    }
}