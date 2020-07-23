using Movie.API.Data;
using Movie.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Domain.Services
{
    public class MovieRepository : IMovieRepository
    {
        private MoviesContext _context;
        private IMovieService _service;

        public MovieRepository(MoviesContext context, MovieService service)
        {
            _context = context;
            _service = service;
        }

        public IEnumerable<Movies> GetMovies() => _context.Movies;
        public Movies GetMovie(int movieId) => _context.Movies.Where(x => x.Id == movieId).SingleOrDefault();

        public void SaveDetail(Movies movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public IEnumerable<MovieRatings> GetMovieRatings() => _context.MovieRatings;

    }
}
