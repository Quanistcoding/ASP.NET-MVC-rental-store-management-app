﻿using System;
using System.Collections.Generic;
using System.Data;
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
    [Authorize]
    [Authorize(Roles = "admin")]
    public class MembershipTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MembershipTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.MembershipTypes.ToListAsync());
        }

        // GET: MembershipTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MembershipTypes == null)
            {
                return NotFound();
            }

            var membershipType = await _context.MembershipTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membershipType == null)
            {
                return NotFound();
            }

            return View(membershipType);
        }

        // GET: MembershipTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembershipTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DiscountRate")] MembershipType membershipType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membershipType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membershipType);
        }

        // GET: MembershipTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MembershipTypes == null)
            {
                return NotFound();
            }

            var membershipType = await _context.MembershipTypes.FindAsync(id);
            if (membershipType == null)
            {
                return NotFound();
            }
            return View(membershipType);
        }

        // POST: MembershipTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DiscountRate")] MembershipType membershipType)
        {
            if (id != membershipType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membershipType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipTypeExists(membershipType.Id))
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
            return View(membershipType);
        }

        // GET: MembershipTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MembershipTypes == null)
            {
                return NotFound();
            }

            var membershipType = await _context.MembershipTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membershipType == null)
            {
                return NotFound();
            }

            return View(membershipType);
        }

        // POST: MembershipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MembershipTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MembershipTypes'  is null.");
            }
            var membershipType = await _context.MembershipTypes.FindAsync(id);
            if (membershipType != null)
            {
                _context.MembershipTypes.Remove(membershipType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipTypeExists(int id)
        {
          return _context.MembershipTypes.Any(e => e.Id == id);
        }
    }
}
