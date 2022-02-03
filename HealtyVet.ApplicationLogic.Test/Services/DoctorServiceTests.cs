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
    public class DoctorServiceTest
    {

        private Mock<IDoctorRepository> doctorRepoMock = new Mock<IDoctorRepository>();
        private Mock<IServiceRepository> serviceRepoMock = new Mock<IServiceRepository>();


        private Guid existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");



        [TestInitialize]
        public void InitializeTest()
        {


            var doctor = new Doctor
            {
                Id = existingUserId,
                Email = "blabla@mail.com",
                FirstName = "BlaBla",
                LastName = "lalalla",
                PhoneNumber = "1234567",
                Address = "Strada",

            };

            doctorRepoMock.Setup(doctorRepo => doctorRepo.GetDoctorById(existingUserId))
                            .Returns(doctor);

        }

        [TestMethod]
        public void GetDoctorByUserId_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange

            var doctorService = new DoctorService(doctorRepoMock.Object, serviceRepoMock.Object);
            var badUserId = "dddd fffff ggg ss";


            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                doctorService.GetDoctorByUserId(badUserId);
            });
        }

        [TestMethod]
        public void GetDoctorByUserId_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            //arrange
            var nonExistingUserId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";

            var doctorService = new DoctorService(doctorRepoMock.Object, serviceRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                doctorService.GetDoctorByUserId(nonExistingUserId);
            });
        }
        [TestMethod]
        public void GetDoctorById_Returns_UserWhenExists()
        {

            Exception throwException = null;
            var doctorService = new DoctorService(doctorRepoMock.Object, serviceRepoMock.Object);
            Doctor user = null;
            //act   
            try
            {
                Guid existingId = Guid.Parse(existingUserId.ToString());
                user = doctorService.GetDoctorById(existingId);
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