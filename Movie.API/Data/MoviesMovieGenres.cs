using System;
using System.Collections.Generic;

namespace Movie.API.Data
{
    public partial class MoviesMovieGenres
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public int MovieGenreId { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
