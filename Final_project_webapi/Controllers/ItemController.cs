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
        public async Task<ActionResult<List<Item>>> GetAll()
        {
            return Ok(await itemService.GetAll());
        }

        //Add new item
        [HttpPost("add")]
        public async Task<ActionResult<Item>> Add(Item item)
        {
            return Ok(await itemService.Add(item));
        }

        //Get Specific Item
        [HttpGet("getItem/{id}")]
        public async Task<ActionResult<ServiceResponse<Item>>> GetItemById(int id)
        {
            return Ok(await itemService.GetItemById(id));
        }

        //Update Item
        [HttpPut("updateItem")]
        public async Task<ActionResult<ServiceResponse<Item>>> UpdateItem(Item item)

        {
            return Ok(await itemService.UpdateItem(item));
        }

        [HttpDelete("deleteItem/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Item>>>> DeleteItem(int id)
        {
            return Ok(await itemService.DeleteItem(id));
        }

        //Get By User
        [HttpGet("itemByUser/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Item>>>> GetItemByUser(int userId)
        {
            return Ok(await itemService.GetItemByUser(userId));
        }

        //Get Item By Department
        [HttpGet("itemByDepartment/{departmentType}")]
        public async Task<ActionResult<ServiceResponse<List<Item>>>> ItemByDepartmentName(DepartmentType departmentType)
        {
            return Ok(await itemService.ItemByDepartmentName(departmentType));
        }
    }
}
