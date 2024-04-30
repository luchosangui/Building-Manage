using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain;
using Logic;
using ILogic;
using IData;
using System.Threading.Tasks;
using APIModels.InputModels;
using APIModels.OutputModels;

namespace Test
{
    [TestClass]
    public class UserTest
    {
        

        //[TestInitialize]
        //public void Setup()
        //{
        //    _mockRepository = new Mock<IGenericRepository<User>>();
        //    _userLogic = new UserLogic(_mockRepository.Object);
        //}

        [TestMethod]
        public void ValidCreateUser()
        {
            // Arrange
            var user = new User("Luis", 
                                "Sanguinetti", 
                                "test@test.com", 
                                UserRole.Administrator, 
                                1,
                                "password"
                                );
            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<User>())).Returns(user);
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
            mockRepo.VerifyAll();
        }

        [TestMethod]
        public void ValidDeleteUser()
        {
            var user = new User(
                                "Luis",
                                "Sanguinetti",
                                "test@test.com",
                                UserRole.Administrator,
                                1,
                                "password"
                                );

            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<User>())).Returns(user);
            IUserLogic logic = new UserLogic(mockRepo.Object);

            

            // Act
            logic.DeleteUser(user.Id);

            // Assert
            mockRepo.VerifyAll();
        }

        
        [TestMethod]
        public void UpdateUserOk()
        {
            // Arrange
            var user = new User("Luis",
                                "Sanguinetti",
                                "test@test.com",
                                UserRole.Administrator,
                                1,
                                "password"
                                );
            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<User>())).Returns(user);
            IUserLogic logic = new UserLogic(mockRepo.Object);

            var updated = new UserRequest(
                "Luis",
                "Sanguinetti",
                "test@new.com",
                UserRole.Administrator,
                "password"

                );

            // Act
            UserResponse result = logic.UpdateUser(user.Id, updated);
            // Assert
            mockRepo.VerifyAll();
            Assert.AreEqual(updated.Email, result.Email);
        }
    }
}
