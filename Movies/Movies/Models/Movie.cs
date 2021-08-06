using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; } 
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; } 
        public int Rating { get; set; }

        public string Reviews { get; set; }

        public int MovieLength { get; set; }

        public IList<MovieActor> MovieActors { get; set; }
           
    }
}
