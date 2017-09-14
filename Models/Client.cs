using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BackEndCapstone.Models
{

    // This is a model for clients

    public class Client
    {
        // Primary Key
        [Key]
        public int ClientId {get; set;}

        // Client's First Name
        [Required]
        [StringLength(50)]
        public string FirstName {get; set;}

        // Client's LastName
        [Required]
        [StringLength(50)]
        public string LastName {get; set;}

        // Phone Number
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        // Email Address
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // A client can have many appointments so have a collection of Appointments
        public ICollection<Appointment> Appointments {get; set;}
    }
}