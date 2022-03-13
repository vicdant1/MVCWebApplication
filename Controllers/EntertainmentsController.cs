#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Data;
using MVCWebApplication.Models.Entertainment;

namespace MVCWebApplication.Controllers
{
    public class EntertainmentsController : Controller
    {
        private readonly AppDbContext _context;

        public EntertainmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Entertainments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entertainment.ToListAsync());
        }

        // GET: Entertainments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entertainment = await _context.Entertainment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entertainment == null)
            {
                return NotFound();
            }

            return View(entertainment);
        }

        // GET: Entertainments/Create
        public IActionResult Create()
        {
            return PartialView("~/Views/Entertainments/_Create.cshtml");
        }

        // POST: Entertainments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Year,Type,Country,SawAt")] Entertainment entertainment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entertainment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView("~/Views/Entertainments/_Create.cshtml", entertainment);
        }

        // GET: Entertainments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entertainment = await _context.Entertainment.FindAsync(id);
            if (entertainment == null)
            {
                return NotFound();
            }
            return View(entertainment);
        }

        // POST: Entertainments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Year,Type,Country,SawAt")] Entertainment entertainment)
        {
            if (id != entertainment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entertainment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntertainmentExists(entertainment.Id))
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
            return View(entertainment);
        }

        // GET: Entertainments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entertainment = await _context.Entertainment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entertainment == null)
            {
                return NotFound();
            }

            return View(entertainment);
        }

        // POST: Entertainments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entertainment = await _context.Entertainment.FindAsync(id);
            _context.Entertainment.Remove(entertainment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntertainmentExists(int id)
        {
            return _context.Entertainment.Any(e => e.Id == id);
        }
    }
}
