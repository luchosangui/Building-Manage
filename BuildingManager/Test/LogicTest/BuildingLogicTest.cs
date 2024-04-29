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
    public class BuildingLogicTest
    {

        [TestMethod]
        public void ValidCreateBuilding()
        {

            //Arrange
            var user = new User("Luis",
                               "Sanguinetti",
                               "test@test.com",
                               UserRole.Administrator,
                               1,
                               "password"
                               );

            var user2 = new User("Luis",
                              "Sanguinetti",
                              "test@test.com",
                              UserRole.Administrator,
                              1,
                              "password"
                              );
            var owner = new User("Luis",
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
            

            var apartment1 = new Apartment(
                9,
                329,
                owner,
                9,
                12,
                true,
                78432
                );
            var maitenencePerson = new List<User> { user,user2 };
            var apartments = new List<Apartment> { apartment, apartment1};


            var buildingCompany = new BuildingCompany(
                                "LuisCompany",
                                26

                               );

            var building = new Building(
                
                "Building1",
                "Avenida prueba 1234",
                buildingCompany,
                9




                );
            building.Apartments = apartments;
            building.MaintenancePersons = maitenencePerson;

            Mock<IGenericRepository<Building>> mockRepo = new Mock<IGenericRepository<Building>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<Building>())).Returns(building);
            IBuildingLogic logic = new BuildingLogic(mockRepo.Object);

            var expected = new BuildingRequest(
                9,
                "Building1",
                "Avenida prueba 1234",
                buildingCompany
                

                );
            expected.Apartments = apartments;
            expected.MaintenancePersons = maitenencePerson;

            //Act
            BuildingResponse result = logic.CreateBuilding(expected);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Direction, result.Direction);
            Assert.AreEqual(expected.BuildingCompany, result.BuildingCompany);
    

            mockRepo.VerifyAll();

        }

    }
}

