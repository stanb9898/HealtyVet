using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealtyVet.Models.PetOwnerModel
{
    public class GetAllFeedbacksViewModel
    {
        public IEnumerable<Feedback> Feedbacks { get; set; }
        public IEnumerable<Servicii> Servicii { get; set; }
    }
}
