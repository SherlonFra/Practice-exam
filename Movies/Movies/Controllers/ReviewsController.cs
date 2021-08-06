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
    public class ReviewsController : Controller
    {



        private ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListAllReviews")]
        public IActionResult ListAllReviews()
        {
            var reviews = _context.Reviews.OrderByDescending(r=>r.Created).Take(100).ToList<Review>();

            return new JsonResult(reviews);
        }

        [HttpPost]
        public async Task<ActionResult<Review>> PostStudents(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Review), new { id = review.ReviewId }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(long id, Review Review)
        {
            if (id != Review.ReviewId)
            {
                return BadRequest();
            }

            _context.Entry(Review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Review(int id)
        {
            var ReviewItem = await _context.Reviews.FindAsync(id);
            if (ReviewItem == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(ReviewItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
