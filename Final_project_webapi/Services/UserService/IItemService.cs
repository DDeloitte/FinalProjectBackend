using Final_project_webapi.Dtos;
using Final_project_webapi.Models;

namespace Final_project_webapi.Services.UserService
{
    public interface IItemService
    {
        //GetAll Items
        Task<ServiceResponse<List<GetItemDto>>> GetAll();

        //Get Item
        Task<ServiceResponse<GetItemDto>> GetItemById(int id, int qty, int newUserId);

        //Add Item
        Task<ServiceResponse<GetItemDto>> Add(AddItemDto item);

        //Update Item
        Task<ServiceResponse<GetItemDto>> UpdateItem(UpdateItemDto item);

        //Delete Item end point
        Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id);

        //Get Items by UserId
        Task<ServiceResponse<List<GetItemDto>>> GetItemByUser(int id);


        //Get Item By Department
        Task<ServiceResponse<List<GetItemDto>>> ItemByDepartmentName(DepartmentType departmentType);

        //Pending the trading method

    }
}

