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
        public string UserName {  get; set; }


        public InvitationRequest(int id, string email, string userName) { 
                
            Id = id;
            Email = email;
            UserName = userName;
        }

        public InvitationRequest ToInvitationRequest()
        {
            return new InvitationRequest(
               Id = Id,
                Email = Email,
                UserName = UserName

                ) ;
        }
        public Invitation ToEntity() {

            return new Invitation
            {
                Id = Id,
                Email = Email,
                NameUser = UserName
            };
        }
    }
}
