using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rental_Store_Management.Data;
using Rental_Store_Management.Models;

namespace Rental_Store_Management.Controllers
{
    
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rentals.Include(r => r.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Name");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerDriverLicenseNumber,MovieId,DateRented,DateReturned")] Rental rental)
        {
            int movieId = rental.MovieId;

            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Name", movieId);
            

            if (ModelState.IsValid)
            {              
                if (!HasMovies(movieId))
                {
                    TempData["error"] = "Movie rent out.";
                    return View(rental);
                }

                await UpdateMovieCount(-1, movieId);
                _context.Add(rental);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Name", rental.MovieId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerDriverLicenseNumber,MovieId,DateRented,DateReturned")] Rental rental)
        {
            if (id != rental.Id)
            {
                return NotFound();
            }




            if (ModelState.IsValid && rental.DateReturned != null)
            {
                try
                {
                    await UpdateMovieCount(1, rental.MovieId);
                    _context.Update(rental);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = rental.DateReturned == null ? "Must choose a returned date." : null;


            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Name", rental.MovieId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rentals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rentals'  is null.");
            }
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
          return _context.Rentals.Any(e => e.Id == id);
        }

        private bool HasMovies(int MovieId)
        {
            Movie movie = _context.Movies.Find(MovieId);

            if (movie == null || movie.NumberInStock <= 0) return false;

            return true;
        }

        private async Task UpdateMovieCount(int ChangeCount, int movieId)
        {
            _context.Movies.Find(movieId).NumberInStock += ChangeCount;
            await _context.SaveChangesAsync();
        }
    }
}
