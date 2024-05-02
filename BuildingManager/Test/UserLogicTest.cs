using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain;
using Logic;
using ILogic;
using IData;
using System.Threading.Tasks;
using APIModels.InputModels;
using APIModels.OutputModels;
using System.Linq.Expressions;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Test
{
    [TestClass]
    public class UserTest
    {

        private Mock<IGenericRepository<Domain.User>> _mockUserRepo;
        private UserLogic _userLogic;

        [TestInitialize]
        public void Initialize()
        {
            _mockUserRepo = new Mock<IGenericRepository<Domain.User>>();
            _userLogic = new UserLogic(_mockUserRepo.Object);
        }


        [TestMethod]
        public void ValidCreateUser()
        {
            // Arrange
            var user = new Domain.User("Luis", 
                                "Sanguinetti", 
                                "test@test.com", 
                                UserRole.Administrator, 
                                4,
                                "password"
                                );
            Mock<IGenericRepository<Domain.User>> mockRepo = new Mock<IGenericRepository<Domain.User>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<Domain.User>())).Returns(user);
            IUserLogic logic = new UserLogic(mockRepo.Object);

            var expected = new CreateUserRequest(
                "Luis",
                "Sanguinetti",
                "test@test.com",
                UserRole.Administrator,
                "pass"
               
                );

          

            // Act
            UserResponse result = logic.CreateUser(expected);

            // Assert
            Assert.AreEqual(expected.Email, result.Email);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Surname, result.Surname);
            Assert.AreEqual(expected.Role, result.Role);
            Assert.AreEqual(4, result.Id);
            mockRepo.VerifyAll();
        }

        [TestMethod]
        public void ValidDeleteUser()
        {
            var user = new Domain.User("John", "Doe", "john@example.com", UserRole.Administrator, 1, "password");
            _mockUserRepo.Setup(repo => repo.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Domain.User, bool>>>(), null)).Returns(user);

            _userLogic.DeleteUser(1);

            _mockUserRepo.Verify(repo => repo.Delete(user), Times.Once);
        }

        [TestMethod]
        public void ValidGetAllUsers()
        {
            var users = new List<Domain.User>
        {
            new Domain.User("John", "Doe", "john@example.com", UserRole.Administrator, 1, "password"),
            new Domain.User("Jane", "Doe", "jane@example.com", UserRole.Owner, 2, "password")
        };
            _mockUserRepo.Setup(repo => repo.GetAll<Domain.User>()).Returns(users);

            var result = _userLogic.GetAllUsers();

            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(u => u.Name == "John"));
        }

        [TestMethod]
        public void ValidUpdateUser()
        {
            var existingUser = new Domain.User("John", "Doe", "john@example.com", UserRole.Administrator, 1, "password");
            var updateUserRequest = new UserRequest("Johnny", "Doe", "johnny@example.com", UserRole.Administrator, "newpassword");
            _mockUserRepo.Setup(repo => repo.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Domain.User, bool>>>(), null)).Returns(existingUser);
            _mockUserRepo.Setup(repo => repo.Update(It.IsAny<Domain.User>())).Returns((Domain.User u) => u);  // Return the modified user

            var result = _userLogic.UpdateUser(1, updateUserRequest);

            Assert.AreEqual("Johnny", result.Name);
            Assert.AreEqual("johnny@example.com", result.Email);
            
        }

        [TestMethod]
        public void ValidGetUserById()
        {
            var user = new Domain.User("John", "Doe", "john@example.com", UserRole.Administrator, 1, "password");
            _mockUserRepo.Setup(repo => repo.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Domain.User, bool>>>(), null))
                         .Returns(user);

            var result = _userLogic.GetUserById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.Name);
            Assert.AreEqual(1, result.Id);
        }







    }
}
