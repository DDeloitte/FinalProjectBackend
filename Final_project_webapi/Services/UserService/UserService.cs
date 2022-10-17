using Final_project_webapi.Models;

namespace Final_project_webapi.Services.UserService
{
    public class UserService : IUserService
    {
        //Dummy list of users
        private static List<User> usersList = new List<User>()
        {
            new User() {UserId = 1, FName = "David", LName = "Molina", UserType = UserType.User, Phone = 4423187283, Email = "email1@email.com" },
            new User() {UserId = 2, FName = "Guillermo", LName = "Pacheco", UserType = UserType.SystemAdmin, Phone = 4423387273, Email = "email2@email.com" },
            new User() {UserId = 3, FName = "Daniel", LName = "Gamboa", UserType = UserType.SystemAdmin, Phone = 4422187453, Email = "email3@email.com" },
            new User() {UserId = 4, FName = "Oscar", LName = "Guerrero", UserType = UserType.SystemAdmin, Phone = 4429134283, Email = "email4@email.com" }
        };

        //Async is used alongside Task and await to use asynchronous calls, and it´s faster for fetching data from a database
        //ServiceResponse is used alongside the new object and it helps in the frontend to print a better message to the user

        //Add user method
        public async Task<ServiceResponse<List<User>>> Add(User usuario)
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            var userListCount = usersList.Count();
            usuario.UserId = userListCount + 1;
            usersList.Add(usuario);
            serviceResponse.Data = usersList;

            return serviceResponse;
        }

        //Delete User
        public async Task<ServiceResponse<List<User>>> DeleteUser(int id)
        {

            //First identify the user
            foreach (var user in usersList)
            {
                if (user.UserId == id)
                {
                    usersList.Remove(user);
                }
            }

            return new ServiceResponse<List<User>> { Data = usersList };

        }

        //Get all users
        public async Task<ServiceResponse<List<User>>> GetAll()
        {

            return new ServiceResponse<List<User>> { Data = usersList };

        }

        //Get user by Id
        public async Task<ServiceResponse<User>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            var user = usersList.First(user => user.UserId == id);
            serviceResponse.Data = user;
            return serviceResponse;


        }

        //Get number of entries in archives
        public async Task<ServiceResponse<int>> GetCount()
        {
            var usersCount = usersList.Count();
            return new ServiceResponse<int> { Data = usersCount };
        }

        //Update User
        public async Task<ServiceResponse<User>> UpdateUser(User usuario)
        {
            foreach (var user in usersList)
            {
                if (user.UserId == usuario.UserId)
                {
                    user.UserType = usuario.UserType;
                    user.FName = usuario.FName;
                    user.LName = usuario.LName;
                    user.Phone = usuario.Phone;
                    user.Email = usuario.Email;
                }
            }
            return new ServiceResponse<User> { Data = usuario };
        }
    }
}
