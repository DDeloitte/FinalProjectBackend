using Final_project_webapi.Dtos;
using Final_project_webapi.Models;

namespace Final_project_webapi.Services.UserService
{
    /// <summary>
    /// Interface that contains the methods for the User class: get, update, delete...
    /// </summary>
    public interface IUserService
    {
        //GetAll Users
        Task<ServiceResponse<List<User>>> GetAll();

        //Get User
        Task<ServiceResponse<User>> GetById(int id);

        //Add User
        Task<ServiceResponse<User>> Add(User usuario);

        //Update User
        Task<ServiceResponse<User>> UpdateUser(User usuario);

        //Users in datababase
        Task<ServiceResponse<int>> GetCount();

        //Delete User end point
        Task<ServiceResponse<List<User>>> DeleteUser(int id);

    }
}
