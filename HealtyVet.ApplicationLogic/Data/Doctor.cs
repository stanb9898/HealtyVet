using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Data
{
   public class Doctor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
         public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public Feedback Feedbacks { get; set; }
    }
}
