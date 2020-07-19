using System.Collections.Generic;

namespace Movie.API.Domain.Services
{
    public interface IMovieRepository
    {
        IEnumerable<Data.Movie> GetMovies();
    }
}