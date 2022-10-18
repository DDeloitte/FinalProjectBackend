using Final_project_webapi.Models;

namespace Final_project_webapi.Services.UserService
{
    public interface IItemService
    {
        //GetAll Items
        Task<ServiceResponse<List<Item>>> GetAll();

        //Get Item
        Task<ServiceResponse<Item>> GetItemById(int id);

        //Add Item
        Task<ServiceResponse<List<Item>>> Add(Item item);

        //Update Item
        Task<ServiceResponse<Item>> UpdateItem(Item item);

        //Delete Item end point
        Task<ServiceResponse<List<Item>>> DeleteItem(int id);

        //Delete Items by UserId
        Task<ServiceResponse<List<Item>>> GetItemByUser(int id);


        //Get Item By Department
        Task<ServiceResponse<List<Item>>> ItemByDepartmentName(DepartmentType departmentType);

    }
}

