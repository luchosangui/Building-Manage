using APIModels.InputModels;
using APIModels.OutputModels;

namespace ILogic
{
    public interface IUserLogic
    {
        public UserResponse CreateUser(CreateUserRequest userRequest);
    }
}
