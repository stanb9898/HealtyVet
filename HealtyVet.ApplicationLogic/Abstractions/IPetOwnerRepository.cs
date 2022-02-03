using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Abstractions
{
    public interface IPetOwnerRepository : IRepository<PetOwner>
    {
        PetOwner GetPetOwnerById(Guid petownerId);

        PetOwner GetPetOwnerByUserId(Guid userId);

        void Add(Feedback feedback);
    }
}
