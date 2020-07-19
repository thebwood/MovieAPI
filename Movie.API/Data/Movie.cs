using System;
using System.Collections.Generic;

namespace Movie.API.Data
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int MovieRatingId { get; set; }
    }
}
