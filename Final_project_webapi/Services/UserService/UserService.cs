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

        public List<User> Add(User usuario)
        {
            var userListCount = usersList.Count();
            usuario.UserId = userListCount + 1;
            usersList.Add(usuario);
            return usersList;
        }

        public List<User> DeleteUser(int id)
        {

            //First identify the user
            foreach (var user in usersList)
            {
                if (user.UserId == id)
                {
                    usersList.Remove(user);
                }
            }

            return usersList;

        }

        public List<User> GetAll()
        {

            return usersList;

        }

        public User GetById(int id)
        {

            var user = usersList.First(user => user.UserId == id);
            return user;


        }

        public int GetCount()
        {
            var usersCount = usersList.Count();
            return usersCount;
        }

        public User UpdateUser(User usuario)
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
            return usuario;
        }
    }
}
