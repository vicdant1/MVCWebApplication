#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Data;
using MVCWebApplication.Helpers;
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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Entertainment.ToListAsync());
        }

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

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return PartialView("~/Views/Entertainments/_AddOrEdit.cshtml");
            }

            var model = await _context.Entertainment.FindAsync(id);
            if (model == null) return BadRequest("Invalid data source");

            return PartialView("~/Views/Entertainments/_AddOrEdit.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Title,Year,Type,Country,SawAt")] Entertainment entertainment)
        {
            if (ModelState.IsValid)
            {
                string entertainmentStatus = "";

                if(entertainment.Id == 0)
                {
                    _context.Add(entertainment);
                    await _context.SaveChangesAsync();
                    entertainmentStatus = "added";
                }
                else
                {
                    try
                    {
                        _context.Update(entertainment);
                        await _context.SaveChangesAsync();
                        entertainmentStatus = "editted";
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
                }

                return Json(new {isValid = true, 
                                 html=Helper.RenderRazorViewToString(this, "_TableBody", await _context.Entertainment.ToListAsync()),
                                 notification=$"Entertainment {entertainmentStatus} successfully :)"});
            }

                return Json(new {isValid = false,
                                 html=Helper.RenderRazorViewToString(this, "_AddOrEdit", entertainment),
                                 notification = $"Something went wrong :'("
                });
        }

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

            return PartialView("~/Views/Entertainments/_Delete.cshtml", entertainment);
        }

        // POST: Entertainments/Delete/5
        [HttpPost]
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
