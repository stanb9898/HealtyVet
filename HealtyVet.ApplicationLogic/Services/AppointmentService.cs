
using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Services
{
    public class AppointmentService
    {
        readonly IAppointmentRepository appointmentRepository;
        readonly IDoctorRepository doctorRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.doctorRepository = doctorRepository;
        }

        public Appointment GetAppointmentById(Guid Id)
        {
            if (Id == null)
            {
                throw new Exception("Null  id");
            }

            return appointmentRepository.GetAppointmentById(Id);

        }
        public IEnumerable<Appointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        public string GetDoctorId(Guid id)
        {
            var x = doctorRepository.GetDoctorById(id);
            return x.FirstName;
        }

        //public void AddAppointment(string userid, string description, DateTime date)
        //{


        //    Guid useridguid = Guid.Empty;
        //    if (!Guid.TryParse(userid, out useridguid))
        //    {
        //        throw new Exception("invalid guid format");
        //    }
        //    Doctor doctor = doctorRepository.GetDoctorByUserId(useridguid);
        //    if (doctor == null)
        //    {
        //        throw new EntityNotFoundException(useridguid);
        //    }

        //    appointmentRepository.Add(new Appointment() { Id = Guid.NewGuid(), Doctor = doctor, Description = description, Date = date });



        //}
       public void AddAppointment(string description, DateTime date)
        {
            appointmentRepository.Add(new Appointment() { Id = Guid.NewGuid(), Description = description, Date = date, Doctor = new Doctor() });
        }
        public void RequestAppointment(string description, DateTime date)
        {
            appointmentRepository.Add(new Appointment() { Id = Guid.NewGuid(), Description = description, Date = date, PetOwner = new PetOwner() });
        }
       
        public void UpdateAppointment(Appointment appointment)
        {
             appointmentRepository.Update(appointment);
        }

    public void DeleteAppointment(Guid serviceId)
    {
        var oneService = appointmentRepository.GetAppointmentById(serviceId);
        appointmentRepository.Delete(oneService);
    }

        public string GetAppointmentDescription(Guid id)
        {
            var classObj = appointmentRepository.GetAppointmentById(id);
            return classObj.Description;
        }
    }
}

