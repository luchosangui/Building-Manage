using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invitation
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public DateTime FechaLimite{ get; set; }

       public string NameUser {  get; set; }

       // public User User { get; set; }

        public Invitation() { }

        public Invitation(int id, string email,string nameUser, DateTime fechaLimite) { 
            
            Id = id;
            Email = email;
            NameUser = nameUser;
            FechaLimite = fechaLimite;

        
        }



    }
}
