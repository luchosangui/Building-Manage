using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain;
using Logic;
using ILogic;
using IData;
using System.Threading.Tasks;
using APIModels.InputModels;
using APIModels.OutputModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test.LogicTest
{
    [TestClass]
    public class ApartmentLogicTest
    {

        [TestMethod]
        public void ValidCreateApartment() {

            //Arrange
            var owner = new Domain.User("Luis",
                               "Sanguinetti",
                               "test1@test.com",
                               UserRole.Administrator,
                               1,
                               "password"
                               );

            var apartment = new Apartment(
                9,
                329,
                owner,
                9,
                12,
                true,
                78432
                );

            Mock<IGenericRepository<User>> mockRepoUser = new Mock<IGenericRepository<User>>();
            mockRepoUser.Setup(repo => repo.Insert(It.IsAny<Domain.User>())).Returns(owner);
            Mock<IGenericRepository<Apartment>> mockRepo = new Mock<IGenericRepository<Apartment>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<Apartment>())).Returns(apartment);
            
            IApartmentLogic logic = new ApartmentLogic(mockRepo.Object,mockRepoUser.Object);

            var expected = new ApartmentRequest(
                78432,
                9,
                329,
                owner.Id,
                9,
                12,
                true

                );

            //Act
            ApartmentResponse result = logic.CreateApartment(expected);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Floor, result.Floor);
            Assert.AreEqual(expected.Number, result.Number);
            Assert.AreEqual(expected.OwnerId, result.Owner.Id);
            Assert.AreEqual(expected.NumberOfBathrooms, result.NumberOfBathrooms);
            Assert.AreEqual(expected.NumberOfBedrooms, result.NumberOfBedrooms);
            Assert.AreEqual(expected.HasTerrace, result.HasTerrace);
            mockRepo.VerifyAll();

        }
        
    }
}

