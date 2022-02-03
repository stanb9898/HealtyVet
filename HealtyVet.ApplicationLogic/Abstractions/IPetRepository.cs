using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Abstractions
{
    public interface IPetRepository : IRepository<Pet>
    {
        Pet GetPetById(Guid petId);
    }
}
