using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Abstractions
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Appointment GetAppointmentById(Guid appointmentId);
    }
}
