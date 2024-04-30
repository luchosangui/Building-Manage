using APIModels.InputModels;
using APIModels.OutputModels;

namespace ILogic
{
    public interface IUserLogic
    {
        public UserResponse CreateUser(CreateUserRequest userRequest);
        public IEnumerable<UserResponse> GetAllUsers();
        public void DeleteUser(int id);
        public UserResponse GetUserById(int id);
        public UserResponse UpdateUser(int id, UserRequest updatedUser);


    }
}
