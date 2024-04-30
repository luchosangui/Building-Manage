using APIModels.InputModels;
using APIModels.OutputModels;

namespace ILogic
{
    public interface IInvitationLogic
    {
        public InvitationResponse CreateInvitation(InvitationRequest invitationRequest);
        public UserResponse AcceptInvitation(AcceptInvitationRequest acceptInvitationRequest);
    }
}
