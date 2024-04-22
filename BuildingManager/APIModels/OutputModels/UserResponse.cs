using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.OutputModels
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }


        public UserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Role = user.Role;

        }
    }

}
