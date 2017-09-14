using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BackEndCapstone.Models
{

    // This is a model for services
    
    public class Service
    {
        // Primary Key
        [Key]
        public int ServiceId {get; set;}

        // Name of Service
        public string Name {get; set;}

        // Length of Service is in minutes
        public int LengthOfService {get; set;}

        // A service can be on many appointments so connect the two with a join table and have a collection of AppointmentServices
        public ICollection<AppointmentService> AppointmentServices {get; set;}
    }
}