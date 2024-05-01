using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.InputModels
{
    public class InvitationRequest
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "The 'Email' field is not a valid email address.")]
        public string Email { get; set; }
        public string UserName {  get; set; }

        public DateTime FechaLimite { get; set; }


        public InvitationRequest(int id, string email, string userName, DateTime fechaLimite) { 
                
            Id = id;
            Email = email;
            UserName = userName;
            FechaLimite = fechaLimite;
        }

        public InvitationRequest ToInvitationRequest()
        {
            return new InvitationRequest(
               Id = Id,
                Email = Email,
                UserName = UserName,
                FechaLimite = FechaLimite

                ) ;
        }
        public Invitation ToEntity() {

            return new Invitation
            {
                Id = Id,
                Email = Email,
                NameUser = UserName,
                FechaLimite = FechaLimite
            };
        }
    }
}
