using Final_project_webapi.Models;
using Final_project_webapi.Services.UserService;

namespace Final_project_webapi.Dtos
{
    public class GetUsersDto
    {
        public Guid UserId { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public UserType UserType { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }

    }
    public class AddUserDto
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public UserType UserType { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }

    }
  

}
