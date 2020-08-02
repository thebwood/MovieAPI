using AutoMapper;
using Movie.API.Data;
using Movie.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Domain.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService() { }
        public MovieService(IMovieRepository repo, IMapper mapper)
        {
            _movieRepository = repo;
            _mapper = mapper;
        }

        public IEnumerable<Movies> GetMovies() => _movieRepository.GetMovies();

        public List<MovieSearchResultsModel> SearchMovies(MovieSearchModel model) => _movieRepository.SearchMovies(model);

        public Movies GetMovie(long movieId) => _movieRepository.GetMovie(movieId);

        public IEnumerable<MovieRatings> GetMovieRatings() => _movieRepository.GetMovieRatings();
        public IEnumerable<MovieGenres> GetMovieGenres() => _movieRepository.GetMovieGenres();

        public List<string> SaveDetail(MoviesModel movie)
        {
            var errors = ValidateMovie(movie);
            if(errors.Count() == 0)
            {
                var existingMovie = new Movies();
                if (movie.Id > 0)
                    existingMovie = _movieRepository.GetMovie(movie.Id);

                _mapper.Map<MoviesModel, Movies>(movie, existingMovie);
                _movieRepository.SaveDetail(existingMovie);
            }

            return errors;
        }

        private List<string> ValidateMovie(MoviesModel movie)
        {
            var errors = new List<string>();

            if (String.IsNullOrWhiteSpace(movie.Title))
            {
                errors.Add("Title is required");
            }
            if (String.IsNullOrWhiteSpace(movie.Description))
            {
                errors.Add("Description is required");
            }


            return errors;
        }
    }
}
