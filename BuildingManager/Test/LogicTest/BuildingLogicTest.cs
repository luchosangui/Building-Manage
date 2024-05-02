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
using System.Linq.Expressions;

namespace Test.LogicTest
{
    [TestClass]
    public class BuildingLogicTest
    {

        private Mock<IGenericRepository<Building>> _mockBuildingRepo;
        private Mock<IGenericRepository<BuildingCompany>> _mockBuildingCompanyRepo;
        private BuildingLogic _buildingLogic;

        [TestInitialize]
        public void Initialize()
        {
            _mockBuildingRepo = new Mock<IGenericRepository<Building>>();
            _mockBuildingCompanyRepo = new Mock<IGenericRepository<BuildingCompany>>();
            _buildingLogic = new BuildingLogic(_mockBuildingRepo.Object, _mockBuildingCompanyRepo.Object);
        }

        [TestMethod]
        public void ValidCreateBuilding()
        {
            var buildingRequest = new BuildingRequest(0, "Test Building", "123 Test St", 1);
            var buildingCompany = new BuildingCompany { Id = 1, Name = "Test Company" };
            var building = new Building(buildingRequest.Name, buildingRequest.Direction, buildingCompany, 0);

            _mockBuildingCompanyRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<BuildingCompany, bool>>>(), null))
                               .Returns((Expression<Func<BuildingCompany, bool>> predicate, List<string> includes) => predicate.Compile()(buildingCompany) ? buildingCompany : null);

            _mockBuildingRepo.Setup(repo => repo.Insert(It.IsAny<Building>())).Returns(building);

            var result = _buildingLogic.CreateBuilding(buildingRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Building", result.Name);
            Assert.AreEqual(building.BuildingCompany,buildingCompany);
        }

        [TestMethod]
        public void ValidGetBuildingById()
        {
            var building = new Building("Test Building", "123 Test St", new BuildingCompany { Id = 1, Name = "Test Company" }, 1);
            _mockBuildingRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Building, bool>>>(), null))
                             .Returns(building);

            var result = _buildingLogic.GetBuildingById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Building", result.Name);
        }


        [TestMethod]
        public void InvalidGetBuildingById()
        {
            _mockBuildingRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Building, bool>>>(), null))
                             .Returns((Building)null);

            Assert.ThrowsException<KeyNotFoundException>(() => _buildingLogic.GetBuildingById(999));
        }

        [TestMethod]
        public void ValidDeleteBuilding()
        {
            var building = new Building { Id = 1 };
            _mockBuildingRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Building, bool>>>(), null))
                             .Returns(building);

            _buildingLogic.DeleteBuilding(1);

            _mockBuildingRepo.Verify(repo => repo.Delete(building), Times.Once);
        }

        [TestMethod]
        public void InvalidDeleteBuilding()
        {
            _mockBuildingRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Building, bool>>>(), null))
                             .Returns((Building)null);

            Assert.ThrowsException<ArgumentException>(() => _buildingLogic.DeleteBuilding(999));
        }

        [TestMethod]
        public void ValidUpdateBuilding()
        {
            var building = new Building { Id = 1, Name = "Old Name", Direction = "Old Direction", BuildingCompany = new BuildingCompany { Id = 1, Name = "Company" } };
            var buildingRequest = new BuildingRequest(1, "Updated Name", "Updated Direction", 1);

            _mockBuildingRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Building, bool>>>(), null))
                             .Returns(building);
            _mockBuildingRepo.Setup(repo => repo.Update(It.IsAny<Building>())).Returns((Building args) => args);

            var result = _buildingLogic.UpdateBuilding(1, buildingRequest);

            Assert.AreEqual("Updated Name", result.Name);
            Assert.AreEqual("Updated Direction", result.Direction);
        }


    }
}

