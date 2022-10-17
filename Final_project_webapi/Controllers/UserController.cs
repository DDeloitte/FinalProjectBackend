using Final_project_webapi.Models;

namespace Final_project_webapi.Controllers
{
    [Route("api/[controller]")]//To find this controller when making a call
    [ApiController]//Indicates http api response
    public class UserController : ControllerBase
    {

        //Dummy list of users
        private static List<User> usersList = new List<User>()
        {
            new User() {UserId = 1, FName = "David", LName = "Molina", UserType = UserType.User, Phone = 4423187283, Email = "email1@email.com" },
            new User() {UserId = 2, FName = "Guillermo", LName = "Pacheco", UserType = UserType.SystemAdmin, Phone = 4423387273, Email = "email2@email.com" },
            new User() {UserId = 3, FName = "Daniel", LName = "Gamboa", UserType = UserType.SystemAdmin, Phone = 4422187453, Email = "email3@email.com" },
            new User() {UserId = 4, FName = "Oscar", LName = "Guerrero", UserType = UserType.SystemAdmin, Phone = 4429134283, Email = "email4@email.com" }
        };

        //GetAll Users
        [HttpGet("getAll")]
        public ActionResult<User> GetAll()
        {
            try
            {
                return Ok(usersList);

            }
            catch (Exception Ex)
            {

                return Ok(Ex.Message);
            }

        }
        //Add User
        [HttpPost("add")]
        public ActionResult<User> Add(User usuario)
        {
            var userListCount = usersList.Count();
            usuario.UserId = userListCount + 1;
            usersList.Add(usuario);
            return Ok(usuario);
        }

        //Get User
        [HttpGet("get/{id}")]
        public ActionResult<User> ObtenerUsuario(int id)
        {
            try
            {
                var user = usersList.First(user => user.UserId == id);
                return Ok(user);

            }
            catch (Exception Ex)
            {

                return Ok(Ex.Message);
            }

        }

        //Update User
        [HttpPatch("update")]
        public ActionResult<User> ActualizarUsuario(User usuario)
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
            return Ok(usuario);
        }

        //Users in datababase
        [HttpGet("getCount")]
        public ActionResult<User> GetCount()
        {
            var usersCount = usersList.Count();
            return Ok(usersCount);
        }

        //Delete User end point
        [HttpDelete("delete/{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            try
            {
                //First identify the user
                foreach (var user in usersList)
                {
                    if (user.UserId == id)
                    {
                        usersList.Remove(user);
                    }
                }

                return Ok();
            }
            catch (Exception Ex)
            {

                return Ok(Ex.Message);
            }

        }

    }
}
