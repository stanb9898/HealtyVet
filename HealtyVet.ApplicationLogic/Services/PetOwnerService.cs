using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using HealtyVet.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Services
{
    public class PetOwnerService
    {
        IPetOwnerRepository petownerRepository;
        IFeedbackRepository feedbackRepository;

        public PetOwnerService(IFeedbackRepository feedbackRepository, IPetOwnerRepository petownerRepository)
        {
            this.petownerRepository = petownerRepository;
            this.feedbackRepository = feedbackRepository;
        }

        public PetOwner GetPetOwnerById(Guid Id)
        {
            if (Id == null)
            {
                throw new Exception("Null  id");
            }


            return petownerRepository.GetPetOwnerById(Id);

        }

        public PetOwner GetPetOwnerByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var petOwner = petownerRepository.GetPetOwnerByUserId(userIdGuid);
            if (petOwner == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return petOwner;
        }

        public IEnumerable<PetOwner> GetAll()
        {
            return petownerRepository.GetAll();
        }
        public void AddFeedback(string description)
        {
            feedbackRepository.Add(new Feedback()
            {
                Id = Guid.NewGuid(),
                Description = description,
            });
        }
        public void DeleteFeedback(Guid feedbackId)
        {
            var oneFeedback = feedbackRepository.GetFeedbackById(feedbackId);
            feedbackRepository.Delete(oneFeedback);
        }
        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            return feedbackRepository.GetAll();
        }

    }
}
