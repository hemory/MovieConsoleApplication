using System;
using System.Collections.Generic;
using System.Text;

namespace MovieConsoleApp
{
   public class Movie
    {
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public string YearMade { get; set; }

        public Movie(string movieTitle, string genre, string yearMade)
        {
            MovieTitle = movieTitle;
            Genre = genre;
            YearMade = yearMade;
        }
    }
}
