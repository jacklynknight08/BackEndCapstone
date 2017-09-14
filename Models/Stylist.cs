using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BackEndCapstone.Models
{

    // This class is for stylists

    public class Stylist
    {
        // Primary Key
        [Key]
        public int StylistId {get; set;}

        // Stylist's First Name
        [Required]
        [StringLength(50)]
        public string FirstName {get; set;}

        // Stylist's Last Name
        [Required]
        [StringLength(50)]
        public string LastName {get; set;}

        // A stylist's Start Date
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate {get; set;}

        // A stylist's End Date
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate {get; set;}

        // A stylist can have many appointments so have a collection of Appointments 
        public ICollection<Appointment> Appointments {get; set;}
    }
}