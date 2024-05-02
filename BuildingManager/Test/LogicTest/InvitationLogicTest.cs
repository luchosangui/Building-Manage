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

namespace Test.LogicTest
{
    [TestClass]
    public class InvitationLogicTest
    {

        private readonly Mock<IGenericRepository<Invitation>> _mockInvitationRepo;
        private readonly Mock<IGenericRepository<User>> _mockUserRepo;
        private readonly InvitationLogic _invitationLogic;

        public InvitationLogicTest()
        {
            _mockInvitationRepo = new Mock<IGenericRepository<Invitation>>();
            _mockUserRepo = new Mock<IGenericRepository<User>>();
            _invitationLogic = new InvitationLogic(_mockInvitationRepo.Object, _mockUserRepo.Object);
        }


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
        public void ValidGetInvitationById()
        {
            // Arrange
            int invitationId = 1;
            var invitation = new Invitation { Id = invitationId, Email = "test@example.com", NameUser = "John Doe", FechaLimite = DateTime.Now.AddDays(1) };
            _mockInvitationRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Invitation, bool>>>(), null))
                               .Returns((Expression<Func<Invitation, bool>> predicate, List<string> includes) => predicate.Compile()(invitation) ? invitation : null);

            // Act
            var result = _invitationLogic.GetInvitationById(invitationId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(invitationId, result.Id);
        }

        [TestMethod]
        public void ValidDeleteInvitationy()
        {
            var invitation = new Invitation { Id = 1, Email = "john@example.com", NameUser = "John Doe", FechaLimite = DateTime.Now.AddDays(1) };

            _mockInvitationRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Invitation, bool>>>(), null)).Returns(invitation);
            _mockInvitationRepo.Setup(repo => repo.Delete(It.IsAny<Invitation>()));

            _invitationLogic.DeleteInvitation(1);

            _mockInvitationRepo.Verify(repo => repo.Delete(It.IsAny<Invitation>()), Times.Once);
        }

        [TestMethod]
        public void ValidAcceptInvitation()
        {
            var acceptRequest = new AcceptInvitationRequest
            (
                1,
                "securepassword",
                "Doe"
            );
            var invitation = new Invitation
            {
                Id = 1,
                Email = "john@example.com",
                NameUser = "John Doe",
                FechaLimite = DateTime.Now.AddDays(1)
            };
            var user = new User
            {
                Id = 1,
                Name = "John",
                Email = "john@example.com",
                Surname = "Doe",
                Password = "securepassword",
                Role = (UserRole)2 
            };

            _mockInvitationRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Invitation, bool>>>(), null)).Returns(invitation);
            _mockUserRepo.Setup(repo => repo.Insert(It.IsAny<User>())).Returns(user);

            var result = _invitationLogic.AcceptInvitation(acceptRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual(user.Email, result.Email);
        }

        [TestMethod]
        public void InvalidAcceptInvitation()
        {
            var acceptRequest = new AcceptInvitationRequest
            (
                999,
                "securepassword",
                "Doe"
            );

            _mockInvitationRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Invitation, bool>>>(), null)).Returns((Invitation)null);

            Assert.ThrowsException<KeyNotFoundException>(() => _invitationLogic.AcceptInvitation(acceptRequest));
        }

        [TestMethod]
        public void GetInvitationByIdThrowsKeyNotFoundException()
        {
            // Arrange
            _mockInvitationRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Invitation, bool>>>(), null)).Returns((Invitation)null);

            // Act & Assert
            Assert.ThrowsException<KeyNotFoundException>(() => _invitationLogic.GetInvitationById(999));
        }

    }
}

