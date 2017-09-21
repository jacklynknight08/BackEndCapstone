using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BackEndCapstone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackEndCapstone.Models.ViewModels
{
    public class AppointmentCreateViewModel
    {
        public Appointment Appointment { get; set; }

        // Property to hold all services for selection on edit form
        [Display(Name="Services")]
        public MultiSelectList Services { get; private set; }

        [Display(Name="Clients")]
        public List<SelectListItem> Clients { get; private set; }

        [Display(Name="Stylists")]
        public List<SelectListItem> Stylists { get; private set; }

        // This will accept the selected services on form POST
        public List<int> SelectedServices { get; set; }

        public AppointmentCreateViewModel() {}
        public AppointmentCreateViewModel(ApplicationDbContext context)
        {
            // Select list for clients
            this.Clients = context.Client
                .OrderBy(l => l.FirstName)
                .AsEnumerable()
                .Select(li => new SelectListItem { 
                    Text = li.FirstName,
                    Value = li.ClientId.ToString()
                }).ToList();

            // Add a prompt so that the <select> element isn't blank for a new client
            this.Clients.Insert(0, new SelectListItem { 
                Text = "Choose client...",
                Value = "0"
            }); 

            // Select list for stylists
            this.Stylists = context.Stylist
                .OrderBy(l => l.FirstName)
                .AsEnumerable()
                .Select(li => new SelectListItem { 
                    Text = li.FirstName,
                    Value = li.StylistId.ToString()
                }).ToList();

            // Add a prompt so that the <select> element isn't blank for a new client
            this.Stylists.Insert(0, new SelectListItem { 
                Text = "Choose stylist...",
                Value = "0"
            });

            // Build a list of services
            List<Service> services = context.Service
                .OrderBy(s => s.Name)
                .ToList();

            /*
                This MultiSelectList constructor takes 4 arguments. Here's what they all mean.
                    1. The collection that store all items I want in the <select> element
                    2. The column to use for the `value` attribute
                    3. The column to use for display text
                    4. A list of integers for ones to be pre-selected
             */
            this.Services = new MultiSelectList(services, "ServiceId", "Title", SelectedServices);
    }
}