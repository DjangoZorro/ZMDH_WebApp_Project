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
    public class TherapyController : Controller
    {
        private readonly DBManager _context;

        public TherapyController(DBManager context)
        {
            _context = context;
        }

        // GET: Therapy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Therapies.ToListAsync());
        }

        // GET: Therapy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _context.Therapies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (therapy == null)
            {
                return NotFound();
            }

            return View(therapy);
        }

        // GET: Therapy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Therapy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,PedagoogId")] Therapy therapy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(therapy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(therapy);
        }

        // GET: Therapy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _context.Therapies.FindAsync(id);
            if (therapy == null)
            {
                return NotFound();
            }
            return View(therapy);
        }

        // POST: Therapy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,PedagoogId")] Therapy therapy)
        {
            if (id != therapy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(therapy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TherapyExists(therapy.Id))
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
            return View(therapy);
        }

        // GET: Therapy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _context.Therapies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (therapy == null)
            {
                return NotFound();
            }

            return View(therapy);
        }

        // POST: Therapy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var therapy = await _context.Therapies.FindAsync(id);
            _context.Therapies.Remove(therapy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TherapyExists(int id)
        {
            return _context.Therapies.Any(e => e.Id == id);
        }
    }
}
