using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Domain.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int MovieRatingId { get; set; }
    }
}
