using Final_project_webapi.Models;

namespace Final_project_webapi.Services.UserService
{
    /// <summary>
    /// Interface that contains the methods for the User class: get, update, delete...
    /// </summary>
    public interface IUserService
    {
        //GetAll Users
        List<User> GetAll();

        //Get User
        User GetById(int id);

        //Add User
        List<User> Add(User usuario);

        //Update User
        User UpdateUser(User usuario);

        //Users in datababase
        int GetCount();

        //Delete User end point
        List<User> DeleteUser(int id);

    }
}
