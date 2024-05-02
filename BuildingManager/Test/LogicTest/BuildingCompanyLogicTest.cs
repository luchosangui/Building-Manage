using APIModels.InputModels;
using Domain;
using IData;
using Logic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.LogicTest
{
    [TestClass]
    public class BuildingCompanyLogicTest
    {

        private Mock<IGenericRepository<BuildingCompany>> _mockRepository;
        private BuildingCompanyLogic _buildingCompanyLogic;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IGenericRepository<BuildingCompany>>();
            _buildingCompanyLogic = new BuildingCompanyLogic(_mockRepository.Object);
        }

        [TestMethod]
        public void ValidCreateBuildingCompany()
        {
            var request = new BuildingCompanyRequest(0, "Test Company");
            var buildingCompany = new BuildingCompany { Id = 1, Name = "Test Company" };

            _mockRepository.Setup(repo => repo.Insert(It.IsAny<BuildingCompany>()))
                           .Returns(buildingCompany);

            var result = _buildingCompanyLogic.CreateBuildingCompany(request);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Company", result.Name);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void ValidGetBuildingById()
        {
            var buildingCompany = new BuildingCompany { Id = 1, Name = "Test Company" };
            _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<BuildingCompany, bool>>>(), null))
                           .Returns(buildingCompany);

            var result = _buildingCompanyLogic.GetBuildingById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Company", result.Name);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void InvalidGetBuildingById()
        {
            _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<BuildingCompany, bool>>>(), null))
                           .Returns((BuildingCompany)null);

            Assert.ThrowsException<KeyNotFoundException>(() => _buildingCompanyLogic.GetBuildingById(999));
        }
    }
}
