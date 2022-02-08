using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string ClientName { get; set; }
        [DataType(DataType.Date)]
        // Using the Remote Attribute in the Appointment
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }
        public bool TermsAccepted { get; set; }
    }
}