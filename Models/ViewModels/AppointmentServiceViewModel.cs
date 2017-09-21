using System;
using System.Linq;
using BackEndCapstone.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BackEndCapstone.Models.ViewModels
{
    public class AppointmentServiceViewModel
    {
        public Client Clients {get; set;}

        public Stylist Stylists {get; set;}

        public Appointment Appointment {get; set;}

        public ApplicationUser User { get; set; }
        
        public IEnumerable<Service> Services {get; set;}
    }
}