using System.Collections.Generic;

namespace BackEndCapstone.Models
{
    public class ScheduledAppointment
    {
        public string ClientName {get; set;}

        public string StylistName {get; set;}

        public string ServiceName {get; set;}

        public Appointment Appointment {get; set;}

    }
}