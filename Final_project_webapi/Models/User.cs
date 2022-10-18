namespace Final_project_webapi.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public UserType UserType { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }
    }
}
