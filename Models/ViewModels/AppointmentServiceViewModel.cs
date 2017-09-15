using System.Collections.Generic;

namespace BackEndCapstone.Models.ViewModels
{
    public class AppointmentAppointmentService
    {
        public IEnumerable<Client> Clients {get; set;}

        public IEnumerable<Service> Services {get; set;}

        public IEnumerable<Stylist> Stylists {get; set;}

        public IEnumerable<Appointment> Appointment {get; set;}

        public ApplicationUser User { get; set; }
    }
}