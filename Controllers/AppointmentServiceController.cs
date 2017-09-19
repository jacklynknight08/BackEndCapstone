using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackEndCapstone.Data;
using BackEndCapstone.Models;
using Microsoft.AspNetCore.Identity;

namespace BackEndCapstone.Controllers
{
    public class AppointmentServiceController : Controller
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentServiceController(Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;   
            _userManager = userManager; 
        }

        private Task<ApplicationUser> GetCurrentUserAsyncy() => _userManager.GetUserAsync(HttpContext.User);

        // GET: AppointmentService
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AppointmentService.Include(a => a.Appointment).Include(a => a.Service);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppointmentService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentService = await _context.AppointmentService
                .Include(a => a.Appointment)
                .Include(a => a.Service)
                .SingleOrDefaultAsync(m => m.AppointmentServiceId == id);
            if (appointmentService == null)
            {
                return NotFound();
            }

            return View(appointmentService);
        }

        // GET: AppointmentService/Create
        public IActionResult Create()
        {
            ViewData["AppointmentId"] = new SelectList(_context.Appointment, "AppointmentId", "AppointmentId");
            ViewData["ServiceId"] = new SelectList(_context.Set<Service>(), "ServiceId", "ServiceId");
            return View();
        }

        // POST: AppointmentService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentServiceId,AppointmentId,ServiceId")] AppointmentService appointmentService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentService);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointment, "AppointmentId", "AppointmentId", appointmentService.AppointmentId);
            ViewData["ServiceId"] = new SelectList(_context.Set<Service>(), "ServiceId", "ServiceId", appointmentService.ServiceId);
            return View(appointmentService);
        }

        // GET: AppointmentService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentService = await _context.AppointmentService.SingleOrDefaultAsync(m => m.AppointmentServiceId == id);
            if (appointmentService == null)
            {
                return NotFound();
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointment, "AppointmentId", "AppointmentId", appointmentService.AppointmentId);
            ViewData["ServiceId"] = new SelectList(_context.Set<Service>(), "ServiceId", "ServiceId", appointmentService.ServiceId);
            return View(appointmentService);
        }

        // POST: AppointmentService/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentServiceId,AppointmentId,ServiceId")] AppointmentService appointmentService)
        {
            if (id != appointmentService.AppointmentServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentServiceExists(appointmentService.AppointmentServiceId))
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
            ViewData["AppointmentId"] = new SelectList(_context.Appointment, "AppointmentId", "AppointmentId", appointmentService.AppointmentId);
            ViewData["ServiceId"] = new SelectList(_context.Set<Service>(), "ServiceId", "ServiceId", appointmentService.ServiceId);
            return View(appointmentService);
        }

        // GET: AppointmentService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentService = await _context.AppointmentService
                .Include(a => a.Appointment)
                .Include(a => a.Service)
                .SingleOrDefaultAsync(m => m.AppointmentServiceId == id);
            if (appointmentService == null)
            {
                return NotFound();
            }

            return View(appointmentService);
        }

        // POST: AppointmentService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentService = await _context.AppointmentService.SingleOrDefaultAsync(m => m.AppointmentServiceId == id);
            _context.AppointmentService.Remove(appointmentService);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AppointmentServiceExists(int id)
        {
            return _context.AppointmentService.Any(e => e.AppointmentServiceId == id);
        }
    }
}
