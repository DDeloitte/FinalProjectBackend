using Final_project_webapi.Dtos;
using Final_project_webapi.Models;
using Final_project_webapi.Services.UserService;

namespace Final_project_webapi.Controllers
{
    [Route("api/[controller]")]//To find this controller when making a call
    [ApiController]//Indicates http api response
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        //GetAll Users
        [HttpGet("getAll")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetAll()
        {
            return Ok(await userService.GetAll());
        }
        //Add User
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Add(AddUserDto usuario)
        {
            return Ok(await userService.Add(usuario));
        }

        //Get User
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetById(int id)
        {
            var serviceResponse = await userService.GetById(id);
            if (serviceResponse.Data == null)
            {
                serviceResponse.Success = false;
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        //Update User
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(UpdateUserDto usuario)
        {
            var serviceResponse = await userService.UpdateUser(usuario);
            if(serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        //Users in datababase
        [HttpGet("getCount")]
        public async Task<ActionResult<ServiceResponse<int>>> GetCount()
        {
            return Ok(await userService.GetCount());
        }

        //Delete User end point
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> DeleteUser(int id)
        {
            var serviceResponse = await userService.DeleteUser(id);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

    }
}
