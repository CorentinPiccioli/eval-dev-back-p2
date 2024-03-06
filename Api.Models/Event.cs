namespace Api.Models
{
    /// <summary>
    /// Représente un événement.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Obtient ou définit l'identifiant de l'événement.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtient ou définit le titre de l'événement.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Obtient ou définit la description de l'événement.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Obtient ou définit la date de l'événement.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Obtient ou définit le lieu de l'événement.
        /// </summary>
        public string Location { get; set; }
    }
}