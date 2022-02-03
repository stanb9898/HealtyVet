using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealtyVet.DataAccess
{
    public class PetOwnerRepository : BaseRepository<PetOwner>, IPetOwnerRepository
    {
        private Guid petownerId;

        public PetOwnerRepository(HealtyVetDbContext dbContext) : base(dbContext)
        {

        }

        public void Add(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public PetOwner GetPetOwnerById(Guid petownerId)
        {
            return dbContext.PetOwners
                            .Where(petowner => petowner.Id == petownerId)
                            .FirstOrDefault();
        }

        public PetOwner GetPetOwnerByUserId(Guid userId)
        {
            return dbContext.PetOwners
                            .Where(petowner => petowner.Id == userId).SingleOrDefault();

        }

    }

}
