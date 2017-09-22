using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BackEndCapstone.Models
{

    // This is a class for appointments

    public class Appointment
    {
        // Primary Key
        [Key]
        public int AppointmentId {get; set;}

        // Foreign Key for Stylist
        // An appointment can have a stylist
        [Required]
        public int StylistId {get; set;}

        // Foreign Key for Client
        // An appointment can have a client
        [Required]
        public int ClientId {get; set;}

        [Required]
        public int ServiceId {get; set;}

        // Set DataFormatString to short Time for hour and minute
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
        public DateTime StartTime {get; set;}

        // Set DataFormatString to short Time for hour and minute
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
        public DateTime EndTime {get; set;}

        // Have an AppointmentDate for displaying the long date which includes the actual day ex) "Sunday" and include the month, day, and year
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:D}")]
        public DateTime AppointmentDate {get; set;}

        // Create an instance of a Stylist to pull in stylist data when using appointment model
        public virtual Stylist Stylist {get; set;}

        // Create an instance of a Client to pull in client data when using appointment model
        public virtual Client Client {get; set;}

        // Connecting appointment to appointmentservices by using a collection
        public virtual Service Service {get; set;}

    }
}