using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public enum UserRole
    {
        Administrator,
        MaintenancePerson,
        BuildingManager,
        Owner,

    }
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }

        public User() { }   

        public User(string name, string surname, string email, UserRole role,int id,string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;
            Password = password;
        }

    }
}
