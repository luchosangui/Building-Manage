using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.OutputModels
{
    public class InvitationResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
      //  public User UserId { get; set; }



        public InvitationResponse(Invitation invitation) { 
            Id = invitation.Id;
            Email = invitation.Email;
           // UserId = invitation.User;
        }

    }
}


