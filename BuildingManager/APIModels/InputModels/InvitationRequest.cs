using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.InputModels
{
    public class InvitationRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public User UserId { get; set; }


        public InvitationRequest(int id, string email, User userid) { 
                
            Id = id;
            Email = email;
            UserId = userid;
        }

        public InvitationRequest ToInvitationRequest()
        {
            return new InvitationRequest(
               Id = Id,
                Email = Email,
                UserId = UserId

                );
        }
        public Invitation ToEntity() {

            return new Invitation
            {
                Id = Id,
                Email = Email,
                User = UserId
            };
        }
    }
}
