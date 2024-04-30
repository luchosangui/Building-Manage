using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APIModels.InputModels
{
    public class UserRequest
    {
        
        [StringLength(100, ErrorMessage = "The 'Name' must be less than 100 characters.")]
        public string Name { get; set; }

        
        [StringLength(100, ErrorMessage = "The 'Surname' must be less than 100 characters.")]
        public string Surname { get; set; }

        
        [EmailAddress(ErrorMessage = "The 'Email' field is not a valid email address.")]
        public string Email { get; set; }

      
        public UserRole Role { get; set; }

        
        public string Password { get; set; }

        // public UserRequest() { }

        public UserRequest(string name, string surname, string email, UserRole role, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;
            Password = password;

        }

        public User ToEntity()
        {
            return new User
            {
                Name = Name,
                Surname = Surname,
                Email = Email,
                Role = Role,
                Password = Password
            };
        }
    }
}
