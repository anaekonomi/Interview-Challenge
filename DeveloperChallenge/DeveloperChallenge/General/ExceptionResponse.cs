namespace BeerAPI.Models
{
    /// <summary>
    /// Model which will be used for handling exceptions in web API
    /// </summary>
    public class ExceptionResponse
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        public string Errors { get; set; }
    }
}