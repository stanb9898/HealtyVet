using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Data
{
   public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
       

    }
}
