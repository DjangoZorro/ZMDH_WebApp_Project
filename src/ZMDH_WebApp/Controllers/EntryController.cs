using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZMDH_WebApp.Data;
using ZMDH_WebApp.Models;

namespace ZMDH_WebApp.Controllers
{
    public class EntryController : Controller
    {
        private readonly DBManager _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EntryController(DBManager context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Entry
        public async Task<IActionResult> Index()
        {
            var dBManager = _context.Entries.Include(e => e.Condition);
            return View(await dBManager.ToListAsync());
        }

        // GET: Entry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .Include(e => e.Condition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entry/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Naam");
            return View();
        }

        // POST: Entry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,BirthDate,ZipCode,CityName,HouseNumber,PhoneNumber,EmailAddress,ConditionId,ConsentOfGuardian,GuardianName,EmailAddressGuardian")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Naam", entry.ConditionId);
            return View(entry);
        }

        [HttpGet]
        public async Task<IActionResult> GenerateAccount(EntryGenerateModel entryGenerateModel)
        {
            Entry entry = _context.Entries.Single(a => a.Id == entryGenerateModel.Id);
            var user = new Client
            {
                UserName = entry.EmailAddress,
                Email = entry.EmailAddress,
                ConditionId = entry.ConditionId
            };

            await _userManager.CreateAsync(user, "Test123!");

            return RedirectToAction(nameof(Index));
        }

        // GET: Entry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Naam", entry.ConditionId);
            return View(entry);
        }

        // POST: Entry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,BirthDate,ZipCode,CityName,HouseNumber,PhoneNumber,EmailAddress,ConditionId,ConsentOfGuardian,GuardianName,EmailAddressGuardian")] Entry entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.Id))
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
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Naam", entry.ConditionId);
            return View(entry);
        }

        // GET: Entry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .Include(e => e.Condition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await _context.Entries.FindAsync(id);
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
