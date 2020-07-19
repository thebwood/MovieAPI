using Movie.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Domain.Services
{
    public class MovieRepository : IMovieRepository
    {
        private MoviesContext _context;

        public MovieRepository(MoviesContext context) => _context = context;

        public IEnumerable<Data.Movie> GetMovies() => _context.Movie;
    }
}
