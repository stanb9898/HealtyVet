using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealtyVet.DataAccess
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {

        public AppointmentRepository(HealtyVetDbContext dbContext) : base(dbContext)
        {

        }

        public Appointment GetAppointmentById(Guid appointmentId)
        {
            return dbContext.Appointments
                            .Where(appointment => appointment.Id == appointmentId)
                           .FirstOrDefault();
        }


    }

}
