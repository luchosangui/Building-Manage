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

        public InvitationLogic(IGenericRepository<Invitation> repository)
        {
            _repository = repository;
        }
        //corregir
        public InvitationResponse CreateInvitation(InvitationRequest invitationRequest)
        {
            return new InvitationResponse(_repository.Insert(invitationRequest.ToEntity()));
        }
    }
}
