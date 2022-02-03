using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using HealtyVet.ApplicationLogic.Exceptions;
using HealtyVet.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace HealtyVet.ApplicationLogic.Test
{
    [TestClass]
    public class PetOwnerServiceTest
    {
        
        private Mock<IPetOwnerRepository> petOwnerRepoMock = new Mock<IPetOwnerRepository>();
        private Mock<IFeedbackRepository> feedbackRepoMock = new Mock<IFeedbackRepository>();


        private Guid existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");



        [TestInitialize]
        public void InitializeTest()
        {


            var petOwner = new PetOwner
            {
                Id = existingUserId,
                FirstName = "BlaBla",
                LastName = "lalalla",
                Email = "blabla@mail.com",
                Address = "Strada",
                PhoneNumber = "1234567",
                

            };

            petOwnerRepoMock.Setup(petOwnerRepo => petOwnerRepo.GetPetOwnerById(existingUserId))
                            .Returns(petOwner);

        }

        [TestMethod]
        public void GetPetOwnerByUserId_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange

            var petOwnerService = new PetOwnerService(feedbackRepoMock.Object,petOwnerRepoMock.Object);
            var badUserId = "dddd fffff ggg ss";


            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                petOwnerService.GetPetOwnerByUserId(badUserId);
            });
        }

        [TestMethod]
        public void GetPetOwnerByUserId_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            //arrange
            var nonExistingUserId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";

            var petOwnerService = new PetOwnerService(feedbackRepoMock.Object, petOwnerRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                petOwnerService.GetPetOwnerByUserId(nonExistingUserId);
            });
        }
        [TestMethod]
        public void GetPetOwnerById_Returns_UserWhenExists()
        {

            Exception throwException = null;
            var petOwnerService = new PetOwnerService(feedbackRepoMock.Object, petOwnerRepoMock.Object);
            PetOwner user = null;
            //act   
            try
            {
                Guid existingId = Guid.Parse(existingUserId.ToString());
                user = petOwnerService.GetPetOwnerById(existingId);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(user);
        }

    }
}