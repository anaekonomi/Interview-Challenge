using DeveloperChallenge.DAO;
using DeveloperChallenge.DTO;
using DeveloperChallenge.Interface;
using DeveloperChallenge.Models;
using Microsoft.EntityFrameworkCore;

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

        public void AddRatings(AddRatingsDTO ratings)
        {
            var rate = new Ratings
            {
                Rating = ratings.Rating,
                BeerId = ratings.BeerId
            };
            _context.Ratings.Add(rate);
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
            _context.Ratings.Add(new Ratings { Rating = newRating, BeerId = beerId });

            var beer = _context.Beer.Include(b => b.Ratings).FirstOrDefault(b => b.Id == beerId);

            var count = beer.Ratings.Count;
            var sum = beer.Ratings.Sum(r => r.Rating);

            var avg = sum / count;

            beer.Rating = avg;

            _context.SaveChanges();
        }
    }
}