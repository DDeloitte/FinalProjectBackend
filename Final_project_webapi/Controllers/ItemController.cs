using Final_project_webapi.Dtos;
using Final_project_webapi.Models;
using Final_project_webapi.Services.UserService;

namespace Final_project_webapi.Controllers
{
    [Route("api/[controller]")]//To find this controller when making a call
    [ApiController]//Indicates http api response

    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        //Get All Items
        [HttpGet("getAll")]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> GetAll()
        {
            return Ok(await itemService.GetAll());
        }

        //Add new item
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetItemDto>>> Add(AddItemDto item)
        {
            return Ok(await itemService.Add(item));
        }

        //Get Item By Id
        [HttpGet("getItem/item/{id}/item/{qty}/newUser/{newUserId}")]
        public async Task<ActionResult<ServiceResponse<GetItemDto>>> GetItemById(int id, int qty, int newUserId)
        {
            var serviceResponse = await itemService.GetItemById(id, qty, newUserId);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        //Update Item
        [HttpPut("updateItem")]
        public async Task<ActionResult<ServiceResponse<GetItemDto>>> UpdateItem(UpdateItemDto item)

        {
            var serviceResponse = await itemService.UpdateItem(item);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("deleteItem/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> DeleteItem(int id)
        {
            var serviceResponse = await itemService.DeleteItem(id);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        //Get By User
        [HttpGet("itemByUser/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> GetItemByUser(int userId)
        {
            var response = await itemService.GetItemByUser(userId);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //Get Item By Department
        [HttpGet("itemByDepartment/{departmentType}")]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> ItemByDepartmentName(DepartmentType departmentType)
        {
            var response = await itemService.ItemByDepartmentName(departmentType);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
