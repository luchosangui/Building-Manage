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

        public UserResponse GetUserById(int id)
        {
            User user = _repository.Get(x => x.Id == id);
            return new UserResponse(user);
        }

        public void DeleteUser(int id) { 
            User user =_repository.Get(x => x.Id == id);
            _repository.Delete(user);
        }

        //revisar
        public IEnumerable<UserResponse> GetAllUsers() { 
            var users = _repository.GetAll<User>();
            var listUsers = users.Select(user=>new UserResponse(user));
            return listUsers;
        }

        //public UserResponse updateUser(int id, UserRequest updatedUser) {

        //    User user = _repository.Get(x=>x.Id==id);
        //    if (updatedUser.Email!=null&&) { }
        //}



    }
}
