using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZMDH_WebApp.Data;
using ZMDH_WebApp.Models;

namespace ZMDH_WebApp.Controllers
{
    [Authorize]
    public class PedagoogController : Controller
    {
        private readonly DBManager _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PedagoogController(DBManager context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pedagoog
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SpecSortParm"] = String.IsNullOrEmpty(sortOrder) ? "spec_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "naam_desc" : "";
            ViewData["EmailSortParm"] = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var pedagogen = from x in _context.Pedagogen select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                pedagogen = pedagogen.Where(s => s.name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "naam_desc":
                    pedagogen = pedagogen.OrderBy(s => s.name);
                    break;
                case "email_desc":
                    pedagogen = pedagogen.OrderBy(s => s.Email);
                    break;
                default:
                    pedagogen = pedagogen.OrderBy(s => s.Specialization);
                    break;
            }
            int pageSize = 5;

            return View(await PaginatedList<Pedagoog>.CreateAsync(pedagogen.Include(x => x.Therapy).AsNoTracking(), pageNumber ?? 1, pageSize));
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
        public async Task<IActionResult> Create([Bind("name,Specialization,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Pedagoog pedagoog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedagoog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedagoog);
        }

        [HttpGet]
        public async Task<IActionResult> GenerateAccount()
        {
            var currentPedagoog = await _userManager.GetUserAsync(HttpContext.User);

            bool Found = false;
            foreach (var item in _userManager.Users)
            {
                if(item.GetType().Name.Equals("Pedagoog") && currentPedagoog.Email.Equals(item.Email)) {
                    Found = true;
                }
            }

            if(!Found)
            {
                var newPedagoog = new Pedagoog {
                    UserName = currentPedagoog.UserName,
                    PasswordHash = currentPedagoog.PasswordHash,
                    PhoneNumber = currentPedagoog.PhoneNumber,
                    Email = currentPedagoog.Email
                };
                _context.Add(newPedagoog);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(string id, [Bind("name,Specialization,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Pedagoog pedagoog)
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

        public async Task<IActionResult> Overview()
        {
            return View(await _context.Pedagogen.ToListAsync());
        }
    }
}