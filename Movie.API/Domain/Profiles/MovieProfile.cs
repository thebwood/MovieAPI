using AutoMapper;
using Movie.API.Data;
using Movie.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Domain.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MoviesModel, Movies>();
            CreateMap<Movies, MoviesModel>();
            CreateMap<MovieRatings, MovieRatingsModel>();
        }
    }
}
