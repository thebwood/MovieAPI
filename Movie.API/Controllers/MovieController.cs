using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Domain.Models;
using Movie.API.Domain.Services;

namespace Movie.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieController(IMovieRepository repo, IMapper mapper)
        {
            _movieRepository = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<MoviesModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<MoviesModel>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<MoviesModel>), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetMovies()
        {
            try
            {
                var data = _movieRepository.GetMovies();

                var retVal = _mapper.Map<IEnumerable<MoviesModel>>(data);

                if (retVal.Count() > 0)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{movieId}")]
        [ProducesResponseType(typeof(MoviesModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MoviesModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MoviesModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetMovie(int movieId)
        {
            try
            {
                var data = _movieRepository.GetMovie(movieId);

                var retVal = _mapper.Map<MoviesModel>(data);

                if (retVal != null)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }


        [HttpGet("ratings")]
        [ProducesResponseType(typeof(MovieRatingsModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MovieRatingsModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MovieRatingsModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetMovieRatings()
        {
            try
            {
                var data = _movieRepository.GetMovieRatings();

                var retVal = _mapper.Map<IEnumerable<MovieRatingsModel>>(data);

                if (retVal.Count() > 0)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

    }
}
