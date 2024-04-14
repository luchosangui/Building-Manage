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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        public User() { }   

        public User(string name, string surname, string email, UserRole role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;
        }

    }
}
