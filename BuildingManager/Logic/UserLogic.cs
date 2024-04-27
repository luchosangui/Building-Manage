using APIModels.InputModels;
using APIModels.OutputModels;
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

        public UserResponse CreateUser(CreateUserRequest userRequest)
        {
            return new UserResponse(_repository.Insert(userRequest.ToEntity()));
        }

        public UserResponse GetUser(int id)
        {
            User user = _repository.Get(x => x.Id == id);
            return new UserResponse(user);
        }

    }
}
