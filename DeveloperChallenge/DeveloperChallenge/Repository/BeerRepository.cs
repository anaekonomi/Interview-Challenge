using DeveloperChallenge.DTO;
using DeveloperChallenge.Interface;
using DeveloperChallenge.Models;

namespace DeveloperChallenge.Repository
{
    /// <summary>
    /// Beer Repository
    /// </summary>
    public class BeerRepository : IBeerRepository
    {
        private RepositoryContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public BeerRepository(RepositoryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds beer
        /// </summary>
        /// <param name="beerDto"></param>
        public void AddBeer(AddBeerDTO beerDto)
        {
            var beer = new Beer
            {
                Name = beerDto.Name,
                Type = beerDto.Type,
                Rating = beerDto.Rating
            };

            _context.Beer.Add(beer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all beers
        /// </summary>
        /// <returns></returns>
        public List<Beer> GetAllBeers()
        {
            return _context.Beer.ToList();
        }

        /// <summary>
        /// Searching beers by their name
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Beer> SearchBeers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Beer>();

            return _context.Beer
                .Where(b => b.Name.Contains(searchTerm))
                .ToList();
        }

        /// <summary>
        /// Update beer rating
        /// </summary>
        /// <param name="beerId"></param>
        /// <param name="newRating"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateBeerRating(int beerId, double newRating)
        {
            var beer = _context.Beer.FirstOrDefault(b => b.Id == beerId);
            if (beer == null)
                throw new Exception("Beer not found.");

            if (beer.Rating == null)
                beer.Rating = newRating;
            else
                beer.Rating = (beer.Rating + newRating) / 2;

            _context.SaveChanges();
        }
    }
}