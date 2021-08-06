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
    public class MoviesController : Controller
    {



        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("byMovieName")]

        public IActionResult ListMovies(string Name)
        {
            // Get a list of movies based on actors name
            // Actors > MovieActors > Movies

            // 1) get a list of actors that we'll use as filter
            var actorIds = _context.Actors.Where(a => a.FirstName == Name || a.LastName == Name).Select(a => a.ActorId).ToList();

            // 2) get a list of movieactors that we'll use to filter movies
            var movieIds = _context.MovieActors.Where(ma => actorIds.Contains(ma.ActorId)).Select(ma => ma.MovieId).ToList();

            // 3) Get a list of movies based on the filtered list of movie ids
            var movies = _context.Movies.Where(m => movieIds.Contains(m.MovieId)).Select(m => m.Name).ToList();

            return new JsonResult(movies);
        }
    }
}
