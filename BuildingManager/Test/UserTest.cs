using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain;
using Logic;
using ILogic;
using IData;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class UserTest
    {
        private Mock<IGenericRepository<User>> _mockRepository;
        private IUserLogic _userLogic;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IGenericRepository<User>>();
            _userLogic = new UserLogic(_mockRepository.Object);
        }

        [TestMethod]
        public void ValidCreateUser()
        {
            // Arrange
            var user = new User("Luis", "Sanguinetti", "test@test.com", UserRole.Administrator, 1);
            //_mockRepository.Setup(repo => repo.Insert(It.IsAny<User>())).Verifiable();

            _mockRepository.Verify(repo => repo.Insert(user), Times.Once);


            // Act
            _userLogic.CreateUser(user);

            // Assert
            _mockRepository.Verify(repo => repo.Insert(user), Times.Once);
        }
    }
}
