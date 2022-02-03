using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealtyVet.Models.DoctorModel
{
    public class GetAllServicesViewModel
    {
        public IEnumerable<Servicii> Services { get; set; }
        

    }
}
