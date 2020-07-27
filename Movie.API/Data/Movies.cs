using System;
using System.Collections.Generic;

namespace Movie.API.Data
{
    public partial class Movies
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int MovieRatingsId { get; set; }
        public int? Hours { get; set; }
        public int? Minutes { get; set; }
        public decimal? BoxOffice { get; set; }
        public int? MovieGenresId { get; set; }
    }
}
