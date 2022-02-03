using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealtyVet.Models.AppointmentModel
{
    public class UpdateAppointmentViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }


}


