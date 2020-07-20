using Movie.API.Data;
using System.Collections.Generic;

namespace Movie.API.Domain.Services
{
    public interface IMovieRepository
    {
        IEnumerable<Movies> GetMovies();
    }
}