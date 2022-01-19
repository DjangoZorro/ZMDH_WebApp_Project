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
    public class DiplomaController : Controller
    {
        private readonly DBManager _context;

        public DiplomaController(DBManager context)
        {
            _context = context;
        }

        // GET: Diploma
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diplomas.ToListAsync());
        }

        // GET: Diploma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diploma = await _context.Diplomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diploma == null)
            {
                return NotFound();
            }

            return View(diploma);
        }

        // GET: Diploma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diploma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiplomaName")] Diploma diploma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diploma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diploma);
        }

        // GET: Diploma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diploma = await _context.Diplomas.FindAsync(id);
            if (diploma == null)
            {
                return NotFound();
            }
            return View(diploma);
        }

        // POST: Diploma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiplomaName")] Diploma diploma)
        {
            if (id != diploma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diploma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiplomaExists(diploma.Id))
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
            return View(diploma);
        }

        // GET: Diploma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diploma = await _context.Diplomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diploma == null)
            {
                return NotFound();
            }

            return View(diploma);
        }

        // POST: Diploma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diploma = await _context.Diplomas.FindAsync(id);
            _context.Diplomas.Remove(diploma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiplomaExists(int id)
        {
            return _context.Diplomas.Any(e => e.Id == id);
        }
    }
}
