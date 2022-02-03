using HealtyVet.ApplicationLogic.Services;

using HealtyVet.Models.PetOwnerModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealtyVet.Controllers
{
    public class PetOwnerController: Controller
    {
        private readonly PetOwnerService petOwnerService;
        private readonly UserManager<IdentityUser> userManager;

        public PetOwnerController(UserManager<IdentityUser> userManager, PetOwnerService petOwnerService)
        {
            this.userManager = userManager;
            this.petOwnerService = petOwnerService;
        }


        [HttpGet]
        public IActionResult AddFeedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeedback([FromForm] AddFeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            var userId = userManager.GetUserId(User);
            petOwnerService.AddFeedback(model.Description);

            return Redirect(Url.Action("Index", "PetOwner"));

        }
        [HttpGet]
        public IActionResult DeleteFeedback()
        {
            //create instance

            return View();
        }
        [HttpPost]
        public IActionResult DeleteFeedback(Guid Id)
        {

            petOwnerService.DeleteFeedback(Id);
            return Redirect(Url.Action("Index", "PetOwner"));
        }
        public ActionResult Index()
        {
            try
            {
                var feedbacks = petOwnerService.GetAllFeedbacks();

                return View(new GetAllFeedbacksViewModel { Feedbacks = feedbacks });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
    }

}


