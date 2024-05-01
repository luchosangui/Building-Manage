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

        public void DeleteUser(int id)
        {
            User user = _repository.Get(x => x.Id == id);
            if (user != null)
            {
                _repository.Delete(user);
            }
            else
            {
                throw new ArgumentException("No User Found with ID" + id);
            }

        }



        //revisar
        public IEnumerable<UserResponse> GetAllUsers() { 
            var users = _repository.GetAll<User>();
            var listUsers = users.Select(user=>new UserResponse(user));
            return listUsers;
        }

        public UserResponse UpdateUser(int id, UserRequest updatedUser)
        {
            //conseguir de la base de datos el usuario

            User user = _repository.Get(x => x.Id == id);

            if (updatedUser.Name != null && !"".Equals(updatedUser.Name.Trim()))
            {
                user.Name = updatedUser.Name;
            }

            if (updatedUser.Surname != null && !"".Equals(updatedUser.Surname.Trim()))
            {
                user.Surname = updatedUser.Surname;
            }


            if (updatedUser.Email != null && !"".Equals(updatedUser.Email.Trim()))
            {
                user.Email = updatedUser.Email;
            }

           //user role no puede ser null solo podrian ser iguales pero si lo redefino y son iguales no passa nada
                user.Role = updatedUser.Role;
            

            if (updatedUser.Password != null && !"".Equals(updatedUser.Password.Trim()))
            {
                user.Password = updatedUser.Password;
            }

            var dataUser = _repository.Update(user);
            return new UserResponse(dataUser);


        }



    }
}
