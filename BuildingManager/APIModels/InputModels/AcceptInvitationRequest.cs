using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.InputModels
{
    public class AcceptInvitationRequest
    {

        public int InvitationId { get; set; }
        public string userPassword { get; set; }

        public string Surname { get; set; }

        public AcceptInvitationRequest(int invitationId, string userPassword, string surname)
        {
            InvitationId = invitationId;
            this.userPassword = userPassword;
            Surname = surname;
        }


    }
}
