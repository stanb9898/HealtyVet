using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealtyVet.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HealtyVet.Models.DoctorModel;
using HealtyVet.ApplicationLogic.Data;

namespace HealtyVet.Controllers
{
    public class DoctorController : Controller
    {

        private readonly DoctorService doctorService;
        private readonly UserManager<IdentityUser> userManager;

        public DoctorController(DoctorService doctorService, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.doctorService = doctorService;
        }


        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService([FromForm] AddServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            var userId = userManager.GetUserId(User);
            doctorService.AddService(model.Description, model.Price, model.Type);

            return Redirect(Url.Action("IndexDoctor", "Doctor"));

        }
        [HttpGet]
        public IActionResult DeleteService()
        {
            //create instance

            return View();
        }
        [HttpGet]
        public IActionResult UpdateServicii(Guid id)
        {


            var servicii = doctorService.GetServiceById(id);

            return View(servicii);
        }


        [HttpPost]
        public IActionResult UpdateServicii(Guid id, [FromForm] Servicii suggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            doctorService.UpdateServices(suggestion);
            return Redirect(Url.Action("IndexDoctor", "Doctor"));
        }
        [HttpPost]
        public IActionResult DeleteService(Guid Id)
        {

            doctorService.DeleteService(Id);
            return Redirect(Url.Action("IndexDoctor", "Doctor"));
        }
        public ActionResult IndexDoctor()
        {
            try
            {
                var services = doctorService.GetAllServices();

                return View(new GetAllServicesViewModel { Services = services });
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
                var services = doctorService.GetAllServices();

                return View(new GetAllServicesViewModel { Services = services });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }

        }
    }
}
