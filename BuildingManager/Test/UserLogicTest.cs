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

        //[TestMethod]
        //public void ValidDeleteUser()
        //{
        //var user = new Domain.User(
        //                    "Luis",
        //                    "Sanguinetti",
        //                    "test@test.com",
        //                    UserRole.Administrator,
        //                    1,
        //                    "password"
        //                    );

        //    Mock<IGenericRepository<Domain.User>> mockRepo = new Mock<IGenericRepository<Domain.User>>();
        //    mockRepo.Setup(repo => repo.Insert(It.IsAny<Domain.User>())).Returns(user);
        //   // mockRepo.Setup(repo => repo.Get(It.IsAny<Domain.User>())).Returns(user);
        //    mockRepo.Setup(repo => repo.Delete(user));

        //    IUserLogic logic = new UserLogic(mockRepo.Object);



        //    // Act
        //    logic.DeleteUser(user.Id);

        //    // Assert
        //    mockRepo.VerifyAll();
        //}

        [TestMethod]
        public void DeleteUserOk()
        {
            var user = new Domain.User(
                    "Luis",
                    "Sanguinetti",
                    "test@test.com",
                    UserRole.Administrator,
                    1,
                    "password"
                    );

            Mock<IGenericRepository<Domain.User>> mockRepo = new Mock<IGenericRepository<Domain.User>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<Domain.User>())).Returns(user);
            mockRepo.Setup(repo => repo.Get(p => p.Id == user.Id, null)).Returns(user);
            mockRepo.Setup(repo => repo.Delete(user));

            IUserLogic logic = new UserLogic(mockRepo.Object);

            var expected = new CreateUserRequest(
                "Luis",
                "Sanguinetti",
                "test@test.com",
                UserRole.Administrator,
                "password"

                );


            // Act
            UserResponse result = logic.CreateUser(expected);
            logic.DeleteUser(user.Id);

            // Assert
            mockRepo.VerifyAll();
        }






        [TestMethod]
        public void UpdateUserOk()
        {
            // Arrange
            var user = new Domain.User("Luis",
                                "Sanguinetti",
                                "test@test.com",
                                UserRole.Administrator,
                                1,
                                "password"
                                );
            Mock<IGenericRepository<Domain.User>> mockRepo = new Mock<IGenericRepository<Domain.User>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<Domain.User>())).Returns(user);
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
            
            Assert.AreEqual(updated.Email, result.Email);
            mockRepo.VerifyAll();
        }
    }
}
