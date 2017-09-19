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
        // Create an instance of a client
        public Client Client {get; set;}

        //Create an instance of an appointment
        public Appointment Appointment {get; set;}

        // Give a list of clients
        public List<Client> Clients {get; set;}

        // Give a list of appointments
        public List<Appointment> Appointments {get; set;}

        // Constructor method to create object instance of a list of Computers and Training Programs
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