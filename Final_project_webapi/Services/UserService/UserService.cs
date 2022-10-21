using AutoMapper;
using Final_project_webapi.Data;
using Final_project_webapi.Dtos;
using Final_project_webapi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Final_project_webapi.Services.UserService
{
    public class UserService : IUserService
    {
        //Variables for data injection sqlite and using AutoMapper
        private readonly DataContext context;
        private readonly IMapper mapper;

        //Constructors for data injection and automapper
        public UserService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }


        //Async is used alongside Task and await to use asynchronous calls, and it´s better for fetching data from a database
        //ServiceResponse is used alongside the new object and it helps in the frontend to print a better message to the user

        //Add user method
        public async Task<ServiceResponse<GetUserDto>> Add(AddUserDto usuario)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                
                User user = mapper.Map<User>(usuario);
                user.UserId = context.Users.Count() + 1;
                //user.UserId = context.Users.Last().UserId + 1; 
                context.Users.Add(user);//context.Users is the list in SQL, here we add the user to the database
                await context.SaveChangesAsync();//We save the changes to de DB
                serviceResponse.Data = mapper.Map<GetUserDto>(user);//Prints the user added 

            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }
            

            return serviceResponse;
        }

        //Delete User
        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                User user = await context.Users.FirstAsync(user => user.UserId == id);
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                serviceResponse.Data = context.Users.Select(u => mapper.Map<GetUserDto>(u)).ToList();

            }
            catch (Exception Ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = Ex.Message;
            }

            return serviceResponse;

        }

        //Get all users
        public async Task<ServiceResponse<List<GetUserDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var dbUsers = await context.Users.ToListAsync();
            try
            {
                serviceResponse.Data = dbUsers.Select(c => mapper.Map<GetUserDto>(c)).ToList();
            }
            catch (Exception Ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = Ex.Message;
            }

            return serviceResponse;

        }

        //Get user by Id
        public async Task<ServiceResponse<GetUserDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            var dbUsers = await context.Users.FirstOrDefaultAsync(user => user.UserId == id);
            serviceResponse.Data = mapper.Map<GetUserDto> (dbUsers);


            return serviceResponse;

        }

        //Get number of entries in archives
        public async Task<ServiceResponse<int>> GetCount()
        {
            var serviceResponse = new ServiceResponse<int>();
            try
            {
                var usersCount = await context.Users.CountAsync();
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
        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto usuario)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(user => user.UserId == usuario.UserId);

                mapper.Map(usuario, user);

                //user.UserType = usuario.UserType;
                //user.FName = usuario.FName;
                //user.LName = usuario.LName;
                //user.Phone = usuario.Phone;
                //user.Email = usuario.Email;

                await context.SaveChangesAsync();

                serviceResponse.Data = mapper.Map<GetUserDto>(user);
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
