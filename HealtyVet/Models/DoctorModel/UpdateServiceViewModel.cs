using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealtyVet.Models.DoctorModel
{
    public class UpdateServiceViewModel
    {

        public Guid Id { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

    }
}


