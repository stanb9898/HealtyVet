using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealtyVet.DataAccess
{
    public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
       

        public PetRepository(HealtyVetDbContext dbContext) : base(dbContext)
        {

        }

        public Pet GetPetById(Guid petId)
        {
            return dbContext.Pets
                            .Where(pet => pet.Id == petId)
                            .FirstOrDefault();
        }


    }

}
