namespace DeveloperChallenge.Models
{
    /// <summary>
    /// Beer Model
    /// </summary>
    public class Beer
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Rating
        /// </summary>
        public double? Rating { get; set; }
    }
}