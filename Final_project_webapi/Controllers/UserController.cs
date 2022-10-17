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
        public ActionResult<List<User>> GetAll()
        {
            try
            {
                return Ok(userService.GetAll());

            }
            catch (Exception Ex)
            {

                return Ok(Ex.Message);
            }

        }
        //Add User
        [HttpPost("add")]
        public ActionResult<List<User>> Add(User usuario)
        {
            return Ok(userService.Add(usuario));
        }

        //Get User
        [HttpGet("get/{id}")]
        public ActionResult<User> GetById(int id)
        {
            try
            {

                return Ok(userService.GetById(id));

            }
            catch (Exception Ex)
            {

                return Ok(Ex.Message);
            }

        }

        //Update User
        [HttpPut("update")]
        public ActionResult<User> UpdateUser(User usuario)
        {
            return Ok(userService.UpdateUser(usuario));
        }

        //Users in datababase
        [HttpGet("getCount")]
        public ActionResult<int> GetCount()
        {
            return Ok(userService.GetCount());
        }

        //Delete User end point
        [HttpDelete("delete/{id}")]
        public ActionResult<List<User>> DeleteUser(int id)
        {
            try
            {
                return Ok(userService.DeleteUser(id));
            }
            catch (Exception Ex)
            {

                return Ok(Ex.Message);
            }

        }

    }
}
