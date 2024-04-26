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
        [Required(ErrorMessage = "The 'Name' field is required.")]
        [StringLength(100, ErrorMessage = "The 'Name' must be less than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Surname' field is required.")]
        [StringLength(100, ErrorMessage = "The 'Surname' must be less than 100 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The 'Email' field is required.")]
        [EmailAddress(ErrorMessage = "The 'Email' field is not a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The 'Role' field is required.")]
        public UserRole Role { get; set; }

       // public UserRequest() { }

        public UserRequest(string name, string surname, string email, UserRole role)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;
            
        }

        public User ToEntity()
        {
            return new User
            {
                Name = Name,
                Surname = Surname,
                Email = Email,
                Role = Role
            };
        }
    }
}
