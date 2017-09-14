using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BackEndCapstone.Models;

namespace BackEndCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<BackEndCapstone.Models.Appointment> Appointment { get; set; }

        public DbSet<BackEndCapstone.Models.AppointmentService> AppointmentService { get; set; }

        public DbSet<BackEndCapstone.Models.Client> Client { get; set; }

        public DbSet<BackEndCapstone.Models.Service> Service { get; set; }

        public DbSet<BackEndCapstone.Models.Stylist> Stylist { get; set; }
    }
}
