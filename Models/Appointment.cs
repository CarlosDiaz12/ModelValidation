using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidation.Models
{
    // Applying a Model-Level Custom Validation Attribute
    [NoJoeOnMondays]
    public class Appointment
    {
        [Required]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Please enter a date")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Please enter a date in the future")]
        public DateTime Date { get; set; }
        // Akward
        // [Range(typeof(bool), "true", "true", ErrorMessage = "You must aaccept the terms")]
        [MustBeTrue(ErrorMessage = "You must acept the terms")]
        public bool TermsAccepted { get; set; }
    }
}