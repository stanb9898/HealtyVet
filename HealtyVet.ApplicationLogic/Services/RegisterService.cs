using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Service
{
    public class RegisterService
    {
        IPetOwnerRepository petOwnerRepository;
        IDoctorRepository doctorRepository;

        public RegisterService(IPetOwnerRepository petOwnerRepository, IDoctorRepository doctorRepository)
        {
            this.petOwnerRepository =petOwnerRepository;
            this.doctorRepository = doctorRepository;
        }

        public void AddPetOwner(string firstname, string lastname, string email, string address,string phoneNumber)
        {
            petOwnerRepository.Add(new PetOwner()
            {
                Id = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Address = address,
                PhoneNumber = phoneNumber,
            })  ;
        }

        public void AddDoctor(string firstname, string lastname, string email, string address, string phoneNumber)
        {
            doctorRepository.Add(new Doctor()
            {
                Id = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Address = address,
                PhoneNumber = phoneNumber,
            });
        }
    }
}
