using Final_project_webapi.Data;
using Final_project_webapi.Dtos;
using Final_project_webapi.Models;
using Microsoft.EntityFrameworkCore;
using System;

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
        private readonly DataContext context;

        public UserService(DataContext context)
        {
            this.context = context;
        }

        //Async is used alongside Task and await to use asynchronous calls, and it´s faster for fetching data from a database
        //ServiceResponse is used alongside the new object and it helps in the frontend to print a better message to the user

        //Add user method
        public async Task<ServiceResponse<User>> Add(User usuario)
        {
            var serviceResponse = new ServiceResponse<User>();
            try
            {
                usuario.UserId = 1 + usersList.Count();
                usersList.Add(usuario);
                context.Users.Add(usuario);
                await context.SaveChangesAsync();
                serviceResponse.Data = usuario;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }
            

            return serviceResponse;
        }

        //Delete User
        public async Task<ServiceResponse<List<User>>> DeleteUser(int id)
        {
            ServiceResponse<List<User>> serviceResponse = new ServiceResponse<List<User>>();

            try
            {
                var user = usersList.First(user => user.UserId == id);
                usersList.Remove(user);
                serviceResponse.Data = usersList;

            }
            catch (Exception Ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = Ex.Message;
            }

            return serviceResponse;

        }

        //Get all users
        public async Task<ServiceResponse<List<User>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            try
            {

                serviceResponse.Data = await context.Users.ToListAsync(); ;

            }
            catch (Exception Ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = Ex.Message;
            }

            return serviceResponse;

        }

        //public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        //{
        //    return new ServceResponse<List<GetCharacterDto>>
        //    {
        //        Data = character.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
        //    };
        //}

        //Get user by Id
        public async Task<ServiceResponse<User>> GetById(int id)
        {
            ServiceResponse<User> serviceResponse = new ServiceResponse<User>();
            
            try
            {
                var user = usersList.First(user => user.UserId == id);
                serviceResponse.Data = user;
            }
            catch (Exception Ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = Ex.Message;
            }

            return serviceResponse;

        }

        //Get number of entries in archives
        public async Task<ServiceResponse<int>> GetCount()
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            try
            {
                var usersCount = usersList.Count();
                serviceResponse.Data = usersCount;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }

        //Update User
        public async Task<ServiceResponse<User>> UpdateUser(User usuario)
        {
            ServiceResponse<User> serviceResponse = new ServiceResponse<User>();
            try
            {
                User user = usersList.First(user => user.UserId == usuario.UserId);

                user.UserType = usuario.UserType;
                user.FName = usuario.FName;
                user.LName = usuario.LName;
                user.Phone = usuario.Phone;
                user.Email = usuario.Email;

                serviceResponse.Data = usuario;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }


            return serviceResponse;
        }
    }
}
