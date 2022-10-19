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
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetAll()
        {
            return Ok(await userService.GetAll());
        }
        //Add User
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<User>>> Add(User usuario)
        {
            return Ok(await userService.Add(usuario));
        }

        //Get User
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetById(int id)
        {
            return await userService.GetById(id);
        }

        //Update User
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<User>>> UpdateUser(User usuario)
        {
            return Ok(await userService.UpdateUser(usuario));
        }

        //Users in datababase
        [HttpGet("getCount")]
        public async Task<ActionResult<ServiceResponse<int>>> GetCount()
        {
            return Ok(await userService.GetCount());
        }

        //Delete User end point
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> DeleteUser(int id)
        {
            return await userService.DeleteUser(id);
        }

    }
}
