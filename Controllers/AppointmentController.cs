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
using BackEndCapstone.Models.ViewModels;

namespace BackEndCapstone.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private List<Appointment> scheduledAppointment;
        

        public AppointmentController(Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            scheduledAppointment = _context.Appointment.Include(c => c.Client)
                                       .Include(s => s.Stylist)
                                       .Include(d => d.Service)
                                       .ToList();
        }

        //GET: Appointment
        public ActionResult Index()
        {            
            
            var schedAppt = _context.Appointment.Include(c => c.Client)
                                       .Include(s => s.Stylist)
                                       .Include(d => d.Service)
                                       .ToList();

            return View(schedAppt);      
        }

        // GET: Appointment/Details/5
        public IActionResult Details(int? id)
        {
            var schedAppt = scheduledAppointment;

            if (id == null)
            {
                return NotFound();
            }

            var appointment = schedAppt
                              .SingleOrDefault(s => s.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            AppointmentCreateViewModel model = new AppointmentCreateViewModel(_context);


            // ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "FirstName");
            // ViewData["StylistId"] = new SelectList(_context.Stylist, "StylistId", "FirstName");
            // ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Name");
            return View(model);
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,StylistId,ClientId,StartTime,EndTime,AppointmentDate,ServiceId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "FirstName", appointment.ClientId);
            ViewData["StylistId"] = new SelectList(_context.Stylist, "StylistId", "FirstName", appointment.StylistId);
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.SingleOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ClientId", "FirstName", appointment.ClientId);
            ViewData["StylistId"] = new SelectList(_context.Set<Stylist>(), "StylistId", "FirstName", appointment.StylistId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,StylistId,ClientId,StartTime,EndTime,AppointmentDate")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ClientId", "FirstName", appointment.ClientId);
            ViewData["StylistId"] = new SelectList(_context.Set<Stylist>(), "StylistId", "FirstName", appointment.StylistId);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Client)
                .Include(a => a.Stylist)
                .SingleOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.SingleOrDefaultAsync(m => m.AppointmentId == id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.AppointmentId == id);
        }
    }
}
