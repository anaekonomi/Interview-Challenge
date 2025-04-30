using BeerAPI.Models;
using DeveloperChallenge.DTO;
using DeveloperChallenge.Interface;
using DeveloperChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperChallenge.Controllers
{
    /// <summary>
    /// Beer Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerRepository _beerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="beerRepository"></param>
        public BeerController(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        /// <summary>
        /// Adds beer
        /// </summary>
        /// <param name="beer"></param>
        /// <returns></returns>
        /// <response code="200">Action completed successfully</response>
        /// <response code="400">Bad request object</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 500, type: typeof(ExceptionResponse))]
        public IActionResult AddBeer([FromBody] AddBeerDTO beerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(beerDto);

            if (beerDto == null)
                return BadRequest();

            _beerRepository.AddBeer(beerDto);
            return Ok("Beer added successfully.");
        }

        [HttpPost("add")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 500, type: typeof(ExceptionResponse))]
        public IActionResult AddRating([FromBody] AddRatingsDTO rate)
        {
            if (!ModelState.IsValid)
                return BadRequest(rate);

            if (rate == null)
                return BadRequest();

            _beerRepository.AddRatings(rate);
            return Ok("Rating added successfully.");
        }

        /// <summary>
        /// Get all beers
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Action completed successfully</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(statusCode: 200, type: typeof(List<Beer>))]
        [ProducesResponseType(statusCode: 500, type: typeof(ExceptionResponse))]
        public IActionResult GetAllBeers()
        {
            var beers = _beerRepository.GetAllBeers();
            return Ok(beers);
        }

        /// <summary>
        /// Searches beers
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <response code="200">Action completed successfully</response>
        /// <response code="400">Bad request object</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("search")]
        [ProducesResponseType(statusCode: 200, type: typeof(List<Beer>))]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 500, type: typeof(ExceptionResponse))]
        public IActionResult SearchBeers([FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return BadRequest("Search term cannot be empty.");

            var beers = _beerRepository.SearchBeers(search);
            return Ok(beers);
        }

        /// <summary>
        /// Update beer rating
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newRating"></param>
        /// <returns></returns>
        /// <response code="200">Action completed successfully</response>
        /// <response code="400">Bad request object</response>
        /// <response code="500">Internal server error</response>
        [HttpPatch("{id}/rating")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 500, type: typeof(ExceptionResponse))]
        public IActionResult UpdateBeerRating(int id, [FromQuery] double newRating)
        {
            if (newRating < 1 || newRating > 5)
                return BadRequest("Rating must be between 1 and 5.");

            _beerRepository.UpdateBeerRating(id, newRating);
            return Ok("Beer rating updated successfully.");
        }
    }
}