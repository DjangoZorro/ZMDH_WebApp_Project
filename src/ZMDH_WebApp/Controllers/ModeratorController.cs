using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZMDH_WebApp.Data;
using ZMDH_WebApp.Models;

namespace ZMDH_WebApp.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly DBManager _context;

        public ModeratorController(DBManager context)
        {
            _context = context;
        }

        // GET: Moderator
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moderators.ToListAsync());
        }

        // GET: Moderator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderator = await _context.Moderators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moderator == null)
            {
                return NotFound();
            }

            return View(moderator);
        }

        // GET: Moderator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moderator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Moderator moderator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moderator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moderator);
        }

        // GET: Moderator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderator = await _context.Moderators.FindAsync(id);
            if (moderator == null)
            {
                return NotFound();
            }
            return View(moderator);
        }

        // POST: Moderator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Moderator moderator)
        {
            if (id != moderator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moderator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeratorExists(moderator.Id))
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
            return View(moderator);
        }

        // GET: Moderator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderator = await _context.Moderators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moderator == null)
            {
                return NotFound();
            }

            return View(moderator);
        }

        // POST: Moderator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moderator = await _context.Moderators.FindAsync(id);
            _context.Moderators.Remove(moderator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeratorExists(int id)
        {
            return _context.Moderators.Any(e => e.Id == id);
        }
    }
}