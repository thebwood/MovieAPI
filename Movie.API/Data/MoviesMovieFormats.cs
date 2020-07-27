using System;
using System.Collections.Generic;

namespace Movie.API.Data
{
    public partial class MoviesMovieFormats
    {
        public long Id { get; set; }
        public long? MovieId { get; set; }
        public int? MovieFormatId { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
