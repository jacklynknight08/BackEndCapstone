using System;
using System.Linq;
using BackEndCapstone.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using BackEndCapstone.Data;

namespace BackEndCapstone.Models.ViewModels
{

    // This View Model will let me access clients and their appointments 

    public class ClientAppointmentViewModel
    {
        // Give a list of clients
        public IEnumerable<Client> Clients {get; set;}

        // Give a list of appointments
        public IEnumerable<Appointment> Appointments {get; set;}

        // Retrieve appointments from appointment table where id matches
        // Join client and appointment table to retrieve clients for that appointment
        // Need to pass in ApplicationDBContext
        public ClientAppointmentViewModel(int? id, ApplicationDbContext context)
        {
            Appointments = (from a in context.Appointment
                            where a.ClientId == id
                            join c in context.Client
                            on a.ClientId equals c.ClientId
                            select a).ToList();
        }
    }
}