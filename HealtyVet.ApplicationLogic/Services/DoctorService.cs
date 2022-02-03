using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using HealtyVet.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Services
{


    public class DoctorService
    {
        IDoctorRepository doctorRepository;
        IServiceRepository serviceRepository;

        public DoctorService(IDoctorRepository doctorRepository, IServiceRepository serviceRepository)
        {
            this.doctorRepository = doctorRepository;
            this.serviceRepository = serviceRepository;
        }

        public Doctor GetDoctorById(Guid Id)
        {
            if (Id == null)
            {
                throw new Exception("Null  id");
            }

            return doctorRepository.GetDoctorById(Id);

        }
        public IEnumerable<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }
        public Doctor GetDoctorByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var doctor = doctorRepository.GetDoctorByUserId(userIdGuid);
            if (doctor == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return doctor;
        }
        public void AddService(string description, int price, string type)
        {
            serviceRepository.Add(new Servicii()
            {
                Id = Guid.NewGuid(),
                Description = description,
                Price = price,
                Type = type,
            });

        }
        public void DeleteService(Guid serviceId)
        {
            var oneService = serviceRepository.GetServiceById(serviceId);
            serviceRepository.Delete(oneService);
        }
        public void UpdateServices(Servicii servicii)
        {
            serviceRepository.Update(servicii);
        }

        public void GetDoctorById(string badId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Servicii> GetAllServices()
        {

            return serviceRepository.GetAll();
        }

      

        public Servicii GetServiceById(Guid Id)
        {
            if (Id == null)
            {
                throw new Exception("Null  id");
            }

            return serviceRepository.GetServiceById(Id);

        }

       
    }
}
