using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain;
using Logic;
using ILogic;
using IData;
using System.Threading.Tasks;
using APIModels.InputModels;
using APIModels.OutputModels;

namespace Test.LogicTest
{
    [TestClass]
    public class InvitationLogicTest
    {

        [TestMethod]
        public void ValidCreateInvitation() {

            //Arrange
            var user = new User("Luis",
                               "Sanguinetti",
                               "test1@test.com",
                               UserRole.Administrator,
                               1,
                               "password"
                               );

            var invitation = new Invitation(
                8989,
                "test@test.com",
                user.Name,
                DateTime.MaxValue
                

                );

            Mock<IGenericRepository<Invitation>> mockRepo = new Mock<IGenericRepository<Invitation>>();
            Mock<IGenericRepository<User>> mockUserRepo = new Mock<IGenericRepository<User>>();
            mockUserRepo.Setup(repo => repo.Insert(It.IsAny<User>())).Returns(user);
            mockRepo.Setup(repo => repo.Insert(It.IsAny<Invitation>())).Returns(invitation);
            IInvitationLogic logic = new InvitationLogic(mockRepo.Object, mockUserRepo.Object);

            var expected = new InvitationRequest(
                8989,
                "test@test.com",
                user.Name,
                DateTime.MaxValue
                );

            //Act
            InvitationResponse result = logic.CreateInvitation(expected);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Email, result.Email);
            
            mockRepo.VerifyAll();
        }

        [TestMethod]
        public void ValidDeleteInvitation()
        {
            var user = new User("Luis",
                               "Sanguinetti",
                               "test1@test.com",
                               UserRole.Administrator,
                               1,
                               "password"
                               );

            var invitation = new Invitation(
                8989,
                "test@test.com",
                "testName",
                DateTime.MaxValue
            );

            Mock<IGenericRepository<Invitation>> mockRepo = new Mock<IGenericRepository<Invitation>>();
            Mock<IGenericRepository<Domain.User>> mockRepoUser = new Mock<IGenericRepository<Domain.User>>();

           
            mockRepo.Setup(repo => repo.Get(p => p.Id == invitation.Id, null)).Returns(invitation);
            mockRepo.Setup(repo => repo.Delete(invitation));

            IInvitationLogic logic = new InvitationLogic(mockRepo.Object, mockRepoUser.Object);

            // Act
            
            var fetchedInvitation = logic.GetInvitationById(invitation.Id); 
            logic.DeleteInvitation(invitation.Id);

            // Assert
            mockRepo.VerifyAll();
        }


    }
}

