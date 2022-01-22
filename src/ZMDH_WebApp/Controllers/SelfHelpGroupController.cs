using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZMDH_WebApp.Data;
using ZMDH_WebApp.Models;

namespace ZMDH_WebApp.Controllers
{
    [Authorize]
    public class SelfHelpGroupController : Controller
    {
        private readonly DBManager _context;

        public SelfHelpGroupController(DBManager context)
        {
            _context = context;
        }

        // GET: SelfHelpGroup
        public async Task<IActionResult> Index()
        {
            return View(await _context.SelfHelpGroups.ToListAsync());
        }

        // GET: SelfHelpGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selfHelpGroup = await _context.SelfHelpGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selfHelpGroup == null)
            {
                return NotFound();
            }

            return View(selfHelpGroup);
        }

        // GET: SelfHelpGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SelfHelpGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] SelfHelpGroup selfHelpGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selfHelpGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(selfHelpGroup);
        }

        // GET: SelfHelpGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selfHelpGroup = await _context.SelfHelpGroups.FindAsync(id);
            if (selfHelpGroup == null)
            {
                return NotFound();
            }
            return View(selfHelpGroup);
        }

        // POST: SelfHelpGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] SelfHelpGroup selfHelpGroup)
        {
            if (id != selfHelpGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selfHelpGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelfHelpGroupExists(selfHelpGroup.Id))
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
            return View(selfHelpGroup);
        }

        // GET: SelfHelpGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selfHelpGroup = await _context.SelfHelpGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selfHelpGroup == null)
            {
                return NotFound();
            }

            return View(selfHelpGroup);
        }

        // POST: SelfHelpGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var selfHelpGroup = await _context.SelfHelpGroups.FindAsync(id);
            _context.SelfHelpGroups.Remove(selfHelpGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelfHelpGroupExists(int id)
        {
            return _context.SelfHelpGroups.Any(e => e.Id == id);
        }
    }
}
