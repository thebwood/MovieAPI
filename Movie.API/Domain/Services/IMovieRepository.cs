using Movie.API.Data;
using Movie.API.Domain.Models;
using System.Collections.Generic;

namespace Movie.API.Domain.Services
{
    public interface IMovieRepository
    {
        IEnumerable<Movies> GetMovies();
        Movies GetMovie(long movieId);
        IEnumerable<MovieRatings> GetMovieRatings();
        void SaveDetail(Movies movie);
    }
}