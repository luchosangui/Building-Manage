using Domain;
using IData;
using ILogic;


namespace Logic
{
    public class UserLogic : IUserLogic
    {

        private readonly IGenericRepository<User> _repository;

        public UserLogic(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

       /* public UserResponse CreateUser(UserRequest userRequest)
        {
            // Convert the UserRequest (DTO) to a User domain entity
            var newUser = new User(userRequest.Name, userRequest.Surname, userRequest.Email, userRequest.Role);

            // Add the new user to the repository
            _repository.Insert(newUser);

            // If your repository works with Unit of Work, don't forget to commit your changes.
            // _repository.SaveChanges(); or similar depending on your implementation

            // Optionally, convert the User entity back to a UserResponse (DTO) if needed for the return value
            return new UserResponse(newUser);
        }*/

    }
}
