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
    public class MaintenanceRequestLogicTest {

        private Mock<IGenericRepository<MaintenanceRequest>> _mockMaintenanceRequestRepo;
        private MaintenanceRequestLogic _maintenanceRequestLogic;

        [TestInitialize]
        public void Initialize()
        {
            _mockMaintenanceRequestRepo = new Mock<IGenericRepository<MaintenanceRequest>>();
            _maintenanceRequestLogic = new MaintenanceRequestLogic(_mockMaintenanceRequestRepo.Object);
        }

        [TestMethod]
        public void ValidCreateMaintenanceRequest()
        {
            var maintenanceRequestRequest = new MaintenanceRequestRequest(new Apartment(), "Fix it", new CategoryService(), 0, StateMaintenance.abierto);
            var maintenanceRequest = new MaintenanceRequest(maintenanceRequestRequest.Apartment, maintenanceRequestRequest.Description, maintenanceRequestRequest.CategoryService, maintenanceRequestRequest.Id, maintenanceRequestRequest.StateMaintenance);

            _mockMaintenanceRequestRepo.Setup(repo => repo.Insert(It.IsAny<MaintenanceRequest>())).Returns(maintenanceRequest);

            var result = _maintenanceRequestLogic.CreateMaintenenceRequest(maintenanceRequestRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual("Fix it", result.Description);
        }

        [TestMethod]
        public void ValidGetMaintenanceRequestById()
        {
            var maintenanceRequest = new MaintenanceRequest(new Apartment(), "Fix it", new CategoryService(), 1, StateMaintenance.abierto);
            _mockMaintenanceRequestRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<MaintenanceRequest, bool>>>(), null))
                               .Returns(maintenanceRequest);

            var result = _maintenanceRequestLogic.GetMaintenanceRequestById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Fix it", result.Description);
        }

        //[TestMethod]
        //public void InvalidGetMaintenanceRequestById()
        //{
        //    _mockMaintenanceRequestRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<MaintenanceRequest, bool>>>(), null))
        //                      .Returns((MaintenanceRequest)null);

        //    Assert.ThrowsException<KeyNotFoundException>(() => _maintenanceRequestLogic.GetMaintenanceRequestById(999));
        //}

        [TestMethod]
        public void ValidDeleteMaintenanceRequest()
        {
            var maintenanceRequest = new MaintenanceRequest { Id = 1 };
            _mockMaintenanceRequestRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<MaintenanceRequest, bool>>>(), null))
                              .Returns(maintenanceRequest);

            _maintenanceRequestLogic.DeleteMaintenenceRequest(1);

            _mockMaintenanceRequestRepo.Verify(repo => repo.Delete(maintenanceRequest), Times.Once);
        }

        [TestMethod]
        public void InvalidDeleteMaintenanceRequest()
        {
            _mockMaintenanceRequestRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<MaintenanceRequest, bool>>>(), null))
                              .Returns((MaintenanceRequest)null);

            Assert.ThrowsException<ArgumentException>(() => _maintenanceRequestLogic.DeleteMaintenenceRequest(999));
        }

        [TestMethod]
        public void ValidGetAllMaintenanceRequest()
        {
            var maintenanceRequests = new List<MaintenanceRequest>
        {
            new MaintenanceRequest(new Apartment(), "Fix something", new CategoryService(), 1, StateMaintenance.abierto),
            new MaintenanceRequest(new Apartment(), "Fix something else", new CategoryService(), 2, StateMaintenance.cerrado)
        };

            _mockMaintenanceRequestRepo.Setup(repo => repo.GetAll<MaintenanceRequest>()).Returns(maintenanceRequests);

            var result = _maintenanceRequestLogic.GetAllUMaintenanceRequest();

            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(mr => mr.Description == "Fix something"));
        }

        [TestMethod]
        public void ValidUpdateMaintenanceRequest()
        {
            var maintenanceRequest = new MaintenanceRequest(new Apartment(), "Fix something", new CategoryService(), 1, StateMaintenance.abierto);
            var updatedMaintenanceRequest = new MaintenanceRequestRequest(new Apartment(), "Updated description", new CategoryService(), 1, StateMaintenance.atendido);

            _mockMaintenanceRequestRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<MaintenanceRequest, bool>>>(), null))
                                       .Returns(maintenanceRequest);
            _mockMaintenanceRequestRepo.Setup(repo => repo.Update(It.IsAny<MaintenanceRequest>())).Returns((MaintenanceRequest args) => args);

            var result = _maintenanceRequestLogic.UpdateMaintenanceRequest(1, updatedMaintenanceRequest);

            Assert.AreEqual("Updated description", result.Description);
            Assert.AreEqual(StateMaintenance.atendido, maintenanceRequest.State);
        }

    }

}
