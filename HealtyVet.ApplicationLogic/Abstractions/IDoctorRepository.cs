using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Abstractions
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Doctor GetDoctorById(Guid doctorId);
        Doctor GetDoctorByUserId(Guid userId);
    }

}

