using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Domain.Models
{
    public class MovieSearchModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public int? MovieRatingsId { get; set; }
        public List<int> MovieGenreIds { get; set; }
    }
}
