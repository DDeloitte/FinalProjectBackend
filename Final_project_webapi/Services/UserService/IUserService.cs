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
        Task<ServiceResponse<List<GetUserDto>>> GetAll();

        //Get User
        Task<ServiceResponse<GetUserDto>> GetById(int id);

        //Add User
        Task<ServiceResponse<GetUserDto>> Add(AddUserDto usuario);

        //Update User
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto usuario);

        //Users in datababase
        Task<ServiceResponse<int>> GetCount();

        //Delete User end point
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);

    }
}
