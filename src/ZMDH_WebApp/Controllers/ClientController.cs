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
    public class ClientController : Controller
    {
        private readonly DBManager _context;

        public ClientController(DBManager context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var dBManager = _context.Clienten.Include(c => c.Condition).Include(c => c.Guardian).Include(c => c.SelfHelpGroup);
            return View(await dBManager.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clienten
                .Include(c => c.Condition)
                .Include(c => c.Guardian)
                .Include(c => c.SelfHelpGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id");
            ViewData["GuardianId"] = new SelectList(_context.Guardians, "Id", "Id");
            ViewData["SelfHelpGroupId"] = new SelectList(_context.SelfHelpGroups, "Id", "Id");
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConditionId,GuardianId,SelfHelpGroupId,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id", client.ConditionId);
            ViewData["GuardianId"] = new SelectList(_context.Guardians, "Id", "Id", client.GuardianId);
            ViewData["SelfHelpGroupId"] = new SelectList(_context.SelfHelpGroups, "Id", "Id", client.SelfHelpGroupId);
            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clienten.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id", client.ConditionId);
            ViewData["GuardianId"] = new SelectList(_context.Guardians, "Id", "Id", client.GuardianId);
            ViewData["SelfHelpGroupId"] = new SelectList(_context.SelfHelpGroups, "Id", "Id", client.SelfHelpGroupId);
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConditionId,GuardianId,SelfHelpGroupId,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id", client.ConditionId);
            ViewData["GuardianId"] = new SelectList(_context.Guardians, "Id", "Id", client.GuardianId);
            ViewData["SelfHelpGroupId"] = new SelectList(_context.SelfHelpGroups, "Id", "Id", client.SelfHelpGroupId);
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clienten
                .Include(c => c.Condition)
                .Include(c => c.Guardian)
                .Include(c => c.SelfHelpGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var client = await _context.Clienten.FindAsync(id);
            _context.Clienten.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(string id)
        {
            return _context.Clienten.Any(e => e.Id == id);
        }
    }
}
