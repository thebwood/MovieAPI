using System;
using System.Collections.Generic;

namespace Movie.API.Data
{
    public partial class MovieRatings
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public int Age { get; set; }
    }
}
