using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BackEndCapstone.Models
{

    // This is a class for the join table of appointment services.

    public class AppointmentService
    {
        
        // Primary Key 
        [Key]
        public int AppointmentServiceId {get; set;}

        // Foreign Key for an appointment
        public int AppointmentId {get; set;}

        // Foreign Key for a service
        public int ServiceId {get; set;}

        // An instance of an appointment to include all info from the appointment model
        public virtual Appointment Appointment {get; set;}

        // An instance of a service to include all infor from the service model
        public virtual Service Service {get; set;}
    }
}