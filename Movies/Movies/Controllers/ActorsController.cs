using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Data;
using Movies.Models;
using Microsoft.EntityFrameworkCore;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("byfirstnameorlastname")]

        public IActionResult ListActors(string FirstName, string LastName)
        {
            var actors = _context.Actors.Where
            (
                s => s.LastName == FirstName || s.LastName == LastName

            )
            .ToList<Actor>();

            return new JsonResult(actors);
        }

        [HttpGet]
        [Route("ByMovie")]

        public IActionResult ListActors(string Name)
        {
            // Get list of Movies with that name
            var movieIds = _context.Movies.Where
                (
                    m => m.Name == Name
                ).Select(m => m.MovieId).ToList();

            var movieActors = _context.MovieActors.Where(ma => movieIds.Contains(ma.MovieId)).Select(ma => ma.ActorId).ToList();

            // Get a list of actors that appear in my movieActors list
            var actors = _context.Actors.Where
                (
                    n => movieActors.Contains(n.ActorId)
                )
                .ToList();
            return new JsonResult(actors);




        }
    }
    
}
