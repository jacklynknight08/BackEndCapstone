using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackEndCapstone.Data;
using BackEndCapstone.Models;

namespace BackEndCapstone.Controllers
{
    public class StylistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StylistController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Stylist
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stylist.ToListAsync());
        }

        // GET: Stylist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stylist = await _context.Stylist
                .SingleOrDefaultAsync(m => m.StylistId == id);
            if (stylist == null)
            {
                return NotFound();
            }

            return View(stylist);
        }

        // GET: Stylist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stylist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StylistId,FirstName,LastName,StartDate,EndDate")] Stylist stylist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stylist);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stylist);
        }

        // GET: Stylist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stylist = await _context.Stylist.SingleOrDefaultAsync(m => m.StylistId == id);
            if (stylist == null)
            {
                return NotFound();
            }
            return View(stylist);
        }

        // POST: Stylist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StylistId,FirstName,LastName,StartDate,EndDate")] Stylist stylist)
        {
            if (id != stylist.StylistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stylist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StylistExists(stylist.StylistId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(stylist);
        }

        // GET: Stylist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stylist = await _context.Stylist
                .SingleOrDefaultAsync(m => m.StylistId == id);
            if (stylist == null)
            {
                return NotFound();
            }

            return View(stylist);
        }

        // POST: Stylist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stylist = await _context.Stylist.SingleOrDefaultAsync(m => m.StylistId == id);
            _context.Stylist.Remove(stylist);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StylistExists(int id)
        {
            return _context.Stylist.Any(e => e.StylistId == id);
        }
    }
}
