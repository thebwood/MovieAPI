using Movie.API.Data;
using Microsoft.EntityFrameworkCore;
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

        public MovieRepository(MoviesContext context) => _context = context;

        public IEnumerable<Movies> GetMovies() => _context.Movies;
        public Movies GetMovie(long movieId) => _context.Movies.Where(x => x.Id == movieId).SingleOrDefault();

        public void SaveDetail(Movies movie)
        {
            if (movie.Id > 0)
                _context.Movies.Update(movie);
            else
                _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public IEnumerable<MovieRatings> GetMovieRatings() => _context.MovieRatings;

        public List<MovieSearchResultsModel> SearchMovies(MovieSearchModel searchRequest)
        {
            var results =
                    (from m in _context.Movies
                     join mg in _context.MovieGenres on m.MovieGenresId equals mg.Id into mgs
                     from mg in mgs.DefaultIfEmpty()
                     join mr in _context.MovieRatings on m.MovieRatingsId equals mr.Id into mrs
                     from mr in mrs.DefaultIfEmpty()
                     where ((string.IsNullOrWhiteSpace(searchRequest.Title) || m.Title.Contains(searchRequest.Title)) &&
                     (string.IsNullOrWhiteSpace(searchRequest.Description) || m.Description.Contains(searchRequest.Description))
                     //searchRequest.MovieGenreIds.Contains(m.MovieGenresId.Value) &&
                     //(m.MovieGenresId.HasValue && searchRequest.MovieGenreIds.Contains(m.MovieGenresId.Value)) &&
                     //(searchRequest.MovieRatingIds.Contains(m.MovieRatingsId))
                     )
                     select new MovieSearchResultsModel
                     {
                         Id = m.Id,
                         Title = m.Title,
                         Description = m.Description,
                         Hours = m.Hours,
                         Minutes = m.Minutes,
                         MovieGenre = mg.Description,
                         MovieRating = mr.Rating,
                         BoxOffice = m.BoxOffice
                     })
                    .OrderByDescending(a => a.Id)
                    .Take(1000)
                    .ToList();

            return results;

        }

    }
}
