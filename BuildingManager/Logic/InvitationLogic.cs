using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;


namespace Logic
{
    public class InvitationLogic : IInvitationLogic
    {

        private readonly IGenericRepository<Invitation> _repository;
        private readonly IGenericRepository<User> _repositoryUser;

        public InvitationLogic(IGenericRepository<Invitation> repository, IGenericRepository<User> repositoryUser)
        {
            _repository = repository;
            _repositoryUser = repositoryUser;
        }
        //corregir
        public InvitationResponse CreateInvitation(InvitationRequest invitationRequest)
        {
            return new InvitationResponse(_repository.Insert(invitationRequest.ToEntity()));
        }

        public UserResponse AcceptInvitation(AcceptInvitationRequest acceptInvitationRequest ) {

            Invitation invitation = _repository.Get(x=>x.Id==acceptInvitationRequest.InvitationId);

           

            if (invitation == null)
            {
                throw new KeyNotFoundException($"No invitation found with ID {acceptInvitationRequest.InvitationId}");
            }

            User user = new User()
            {
                Name = invitation.NameUser,
                Email = invitation.Email,
                Role = (UserRole)2,
                Password = acceptInvitationRequest.userPassword,
                Surname = acceptInvitationRequest.Surname
                
            };

           
            var dataUser = _repositoryUser.Insert(user);
            return new UserResponse(dataUser);

        }
    
    }
}
