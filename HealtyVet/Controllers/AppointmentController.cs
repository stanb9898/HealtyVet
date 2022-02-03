using HealtyVet.ApplicationLogic.Services;
using HealtyVet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using HealtyVet.Models.AppointmentModel;
using Microsoft.AspNetCore.Identity;
using HealtyVet.ApplicationLogic.Data;

namespace HealtyVet.Controllers
{

    public class AppointmentController : Controller
    {
        private readonly AppointmentService appointmentService;
        private readonly UserManager<IdentityUser> userManager;

        public AppointmentController(UserManager<IdentityUser> userManager, AppointmentService appointmentService)
        {
            this.userManager = userManager;
            this.appointmentService = appointmentService;
        }


        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }







        [HttpPost]
        public IActionResult AddAppointment([FromForm] AddAppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            var userId = userManager.GetUserId(User);
            appointmentService.AddAppointment(model.Description, model.Date);

            return Redirect(Url.Action("IndexDoctor", "Appointment"));

        }
        [HttpGet]
        public IActionResult DeleteAppointment()
        {
            //create instance

            return View();
        }
        [HttpPost]
        public IActionResult DeleteAppointment(Guid Id)
        {

            appointmentService.DeleteAppointment(Id);
            return Redirect(Url.Action("IndexDoctor", "Appointment"));
        }
        [HttpGet]
        public IActionResult UpdateAppointment(Guid id)
        {


            var appoint = appointmentService.GetAppointmentById(id);

            return View(appoint);
        }

  
        [HttpPost]
        public IActionResult UpdateAppointment(Guid id, [FromForm] Appointment suggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            appointmentService.UpdateAppointment(suggestion);
            return Redirect(Url.Action("IndexDoctor", "Appointment"));
        }
        //GET: Appointment
        public ActionResult IndexDoctor()
        {
            try
            {
                var appointments = appointmentService.GetAll();

                return View(new GetAllAppointmentsViewModel { Appointments = appointments });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
        public ActionResult IndexPetOwner()
        {
            try
            {
                var appointments = appointmentService.GetAll();

                return View(new GetAllAppointmentsViewModel { Appointments = appointments });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

    }
}