using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Data
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public PetOwner PetOwner { get; set; }
        public ICollection<Servicii> Services { get; set; }

    }
}
