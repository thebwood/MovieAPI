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

        [HttpGet("genres")]
        [ProducesResponseType(typeof(MovieModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MovieModel), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MovieModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetStatusTypes()
        {
            try
            {
                var data = _movieRepository.GetMovies();

                var retVal = _mapper.Map<IEnumerable<MovieModel>>(data);

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
