using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Data
{
    public class Servicii
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

    }
}
