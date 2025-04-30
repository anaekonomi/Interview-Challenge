using DeveloperChallenge.Models;

namespace DeveloperChallenge.DAO
{
    public class Ratings
    {
        public int Id { get; set; }
        public double? Rating { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
    }
}
