using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }
        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            // Explicitly Validating a Model

            if (string.IsNullOrWhiteSpace(appt.ClientName))
            {
                ModelState.AddModelError("ClientName", "Please enter yourname");
            }       

            if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
            {
                ModelState.AddModelError("Date", "Please enter a date in the future");
            }

            if (!appt.TermsAccepted)
            {
                ModelState.AddModelError("TermsAccepted", "You must accept the terms");
            }

            if (ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date")
                && appt.ClientName == "Joe" && appt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                // A Model-Level Validation Error
                ModelState.AddModelError("", "Joe cannot book appointments on Mondays");
            }

            if (ModelState.IsValid)
            {
                // statements to store new Appointment in a
                // repository would go here in a real project
                return View("Completed", appt);
            } else
            {
                return View();
            }
        }
    }
}