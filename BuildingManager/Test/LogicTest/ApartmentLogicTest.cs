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
    public class ApartmentLogicTest
    {
        private Mock<IGenericRepository<Apartment>> _mockApartmentRepo;
        private Mock<IGenericRepository<User>> _mockUserRepo;
        private ApartmentLogic _apartmentLogic;

        [TestInitialize]
        public void Initialize()
        {
            _mockApartmentRepo = new Mock<IGenericRepository<Apartment>>();
            _mockUserRepo = new Mock<IGenericRepository<User>>();
            _apartmentLogic = new ApartmentLogic(_mockApartmentRepo.Object, _mockUserRepo.Object);
        }

        [TestMethod]
        public void ValidCreateApartment()
        {
            var apartmentRequest = new ApartmentRequest(0, 5, 101, 1, 2, 1, true);
            var owner = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };
            var apartment = new Apartment(apartmentRequest.Floor, apartmentRequest.Number, owner, apartmentRequest.NumberOfBedrooms, apartmentRequest.NumberOfBathrooms, apartmentRequest.HasTerrace, apartmentRequest.Id);

            _mockUserRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<User, bool>>>(), null))
                         .Returns(owner);
            _mockApartmentRepo.Setup(repo => repo.Insert(It.IsAny<Apartment>())).Returns(apartment);

            var result = _apartmentLogic.CreateApartment(apartmentRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual(101, result.Number);
            Assert.IsTrue(result.HasTerrace);
            Assert.AreEqual(owner, result.Owner);
        }

        [TestMethod]
        public void InvalidCreateApartment()
        {
            var apartmentRequest = new ApartmentRequest(0, 5, 101, 999, 2, 1, true);

            _mockUserRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<User, bool>>>(), null))
                         .Returns((User)null);

            Assert.ThrowsException<KeyNotFoundException>(() => _apartmentLogic.CreateApartment(apartmentRequest));
        }

        [TestMethod]
        public void ValidGetApartmentByIdt()
        {
            var owner = new User { Id = 1, Name = "John Doe" };
            var apartment = new Apartment(5, 101, owner, 2, 1, true, 1);
            _mockApartmentRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Apartment, bool>>>(), null))
                               .Returns(apartment);

            var result = _apartmentLogic.GetApartmentgById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(101, result.Number);
            Assert.AreEqual(owner.Name, result.Owner.Name);
        }

        [TestMethod]
        public void InvalidGetApartmentById()
        {
            _mockApartmentRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Apartment, bool>>>(), null))
                              .Returns((Apartment)null);

            Assert.ThrowsException<KeyNotFoundException>(() => _apartmentLogic.GetApartmentgById(999));
        }

        [TestMethod]
        public void ValidDeleteApartment()
        {
            var apartment = new Apartment { Id = 1 };
            _mockApartmentRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Apartment, bool>>>(), null))
                              .Returns(apartment);

            _apartmentLogic.DeleteApartment(1);

            _mockApartmentRepo.Verify(repo => repo.Delete(apartment), Times.Once);
        }

        [TestMethod]
        public void InvalidDeleteApartment()
        {
            _mockApartmentRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Apartment, bool>>>(), null))
                              .Returns((Apartment)null);

            Assert.ThrowsException<ArgumentException>(() => _apartmentLogic.DeleteApartment(999));
        }

    }
}

