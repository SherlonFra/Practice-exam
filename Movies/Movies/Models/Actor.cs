using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<MovieActor> MovieActors { get; set; }
    }
}
