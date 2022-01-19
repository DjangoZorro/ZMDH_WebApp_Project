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
    public class PedagoogController : Controller
    {
        private readonly DBManager _context;

        public PedagoogController(DBManager context)
        {
            _context = context;
        }

        // GET: Pedagoog
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedagogen.ToListAsync());
        }

        // GET: Pedagoog/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedagoog = await _context.Pedagogen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedagoog == null)
            {
                return NotFound();
            }

            return View(pedagoog);
        }

        // GET: Pedagoog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedagoog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Specialization,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Pedagoog pedagoog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedagoog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedagoog);
        }

        // GET: Pedagoog/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedagoog = await _context.Pedagogen.FindAsync(id);
            if (pedagoog == null)
            {
                return NotFound();
            }
            return View(pedagoog);
        }

        // POST: Pedagoog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Specialization,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Pedagoog pedagoog)
        {
            if (id != pedagoog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedagoog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedagoogExists(pedagoog.Id))
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
            return View(pedagoog);
        }

        // GET: Pedagoog/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedagoog = await _context.Pedagogen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedagoog == null)
            {
                return NotFound();
            }

            return View(pedagoog);
        }

        // POST: Pedagoog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pedagoog = await _context.Pedagogen.FindAsync(id);
            _context.Pedagogen.Remove(pedagoog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedagoogExists(string id)
        {
            return _context.Pedagogen.Any(e => e.Id == id);
        }
    }
}
