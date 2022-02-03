using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealtyVet.DataAccess
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {

        public DoctorRepository(HealtyVetDbContext dbContext) : base(dbContext)
        {

        }

        public Doctor GetDoctorById(Guid doctorId)
        {
            return dbContext.Doctors
                            .Where(doctor => doctor.Id == doctorId)
                            .FirstOrDefault();
        }
        public Doctor GetDoctorByUserId(Guid userId)
        {
            return dbContext.Doctors
                            .Where(doctor => doctor.Id == userId).SingleOrDefault();

        }

    }

}
