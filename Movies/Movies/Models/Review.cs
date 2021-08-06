using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }

        public DateTime Created { get; set; }
    }
}
