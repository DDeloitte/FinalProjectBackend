using Final_project_webapi.Models;

namespace Final_project_webapi.Dtos
{
    public class GetItemDto
    {
        public int itemId { get; set; }
        public string? itemName { get; set; }
        public DepartmentType itemType { get; set; }
        public string? description { get; set; }
        public int quantity { get; set; }
        public int userId { get; set; }
    }
}
