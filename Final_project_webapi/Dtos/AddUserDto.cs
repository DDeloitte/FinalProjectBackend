using Final_project_webapi.Models;

namespace Final_project_webapi.Dtos
{
    public class AddUserDto
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public UserType UserType { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }

    }
}
