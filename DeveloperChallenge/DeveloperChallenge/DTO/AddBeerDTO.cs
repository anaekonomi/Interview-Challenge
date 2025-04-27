using System.ComponentModel.DataAnnotations;

namespace DeveloperChallenge.DTO
{
    /// <summary>
    /// Add Beer DTO
    /// </summary>
    public class AddBeerDTO
    {
        /// <summary>
        /// Name of beer
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Type of beer
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Rating of beer
        /// </summary>
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public double? Rating { get; set; }
    }
}