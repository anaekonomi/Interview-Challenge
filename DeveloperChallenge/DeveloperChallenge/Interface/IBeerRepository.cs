using DeveloperChallenge.DTO;
using DeveloperChallenge.Models;

namespace DeveloperChallenge.Interface
{
    /// <summary>
    /// Interface of Beer Repository
    /// </summary>
    public interface IBeerRepository
    {
        /// <summary>
        /// Adds beer
        /// </summary>
        /// <param name="beerDto"></param>
        void AddBeer(AddBeerDTO beerDto);

        /// <summary>
        /// Gets all beers
        /// </summary>
        /// <returns></returns>
        List<Beer> GetAllBeers();

        /// <summary>
        /// Search beers
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        List<Beer> SearchBeers(string search);

        /// <summary>
        /// Update beer rating
        /// </summary>
        /// <param name="beerId"></param>
        /// <param name="newRating"></param>
        void UpdateBeerRating(int beerId, double newRating);
    }
}