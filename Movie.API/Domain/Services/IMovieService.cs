using Movie.API.Data;
using Movie.API.Domain.Models;
using System.Collections.Generic;

namespace Movie.API.Domain.Services
{
    public interface IMovieService
    {
        List<string> SaveDetail(MoviesModel movie);
        IEnumerable<Movies> GetMovies();
        Movies GetMovie(long movieId);
        IEnumerable<MovieRatings> GetMovieRatings();
        IEnumerable<MovieGenres> GetMovieGenres();
        List<MovieSearchResultsModel> SearchMovies(MovieSearchModel model);
    }
}