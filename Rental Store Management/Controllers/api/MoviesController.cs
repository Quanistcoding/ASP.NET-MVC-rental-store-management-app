using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rental_Store_Management.Data;
using Rental_Store_Management.Models;
using System.Dynamic;

namespace Rental_Store_Management.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoives()
        {
            return await _context.Movies.ToListAsync();
        }

    }
}
