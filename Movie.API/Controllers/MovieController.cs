using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
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
        private IMovieService _service;
        private readonly IMapper _mapper;
        public MovieController(IMovieService service, IMapper mapper)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
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
                var data = _service.GetMovies();

                var retVal = _mapper.Map<IEnumerable<MoviesModel>>(data);

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

        [HttpGet("{movieId}")]
        [ProducesResponseType(typeof(MoviesModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MoviesModel), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(MoviesModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetMovie(int movieId)
        {
            try
            {
                var data = _service.GetMovie(movieId);

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
                var data = _service.GetMovieRatings();

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


        [HttpPost]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateMovie([FromBody] MoviesModel movie)
        {
            var errorList = new List<string>();

            try
            {

                errorList = _service.SaveDetail(movie);
                if (errorList.Count > 0)
                {
                    return BadRequest(errorList);
                }
            }
            catch (Exception ex)
            {
                errorList = new List<string>() { "Error in saving" };
                return BadRequest(errorList);
            }

            return Ok(errorList);
        }


    }
}
