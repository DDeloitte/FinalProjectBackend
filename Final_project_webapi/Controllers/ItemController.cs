using Final_project_webapi.Models;

namespace Final_project_webapi.Controllers
{
    [Route("api/[controller]")]//To find this controller when making a call
    [ApiController]//Indicates http api response

    public class ItemController : ControllerBase
    {
        //Lista predeterminada de archivos de oficina
        private static List<Item> itemsList = new List<Item>()
        {

            new Item() { itemId = 1001, itemName = "CPU", itemType = DepartmentType.IT, description = "CPU data", quantity = 3, userId = 3},
            new Item() { itemId = 1002, itemName = "GPU", itemType = DepartmentType.IT, description = "GPU data", quantity = 5, userId = 4},

            new Item() { itemId = 1003, itemName = "Phone", itemType = DepartmentType.Sales, description = "Phone data", quantity = 11, userId = 1},
            new Item() { itemId = 1004, itemName = "Contact List", itemType = DepartmentType.Sales, description = "Contact List data", quantity = 5, userId = 1},

            new Item() { itemId = 1005, itemName = "Stappler", itemType = DepartmentType.HR, description = "Stappler data", quantity = 7, userId = 2},
            new Item() { itemId = 1006, itemName = "Employees List", itemType = DepartmentType.HR, description = "Employee list data", quantity = 2, userId = 2},

            new Item() { itemId = 1007, itemName = "CNC", itemType = DepartmentType.Production, description = "CNC data", quantity = 1, userId = 4},
            new Item() { itemId = 1008, itemName = "3D Printer", itemType = DepartmentType.Production, description = "3D printer data", quantity = 2, userId = 3},
        };

        //Get All Items
        [HttpGet("getAll")]
        public ActionResult<List<Item>> GetAll()
        {
            return Ok(itemsList);
        }

        //Add new item
        [HttpPost("add")]
        public ActionResult<Item> Add(Item item)
        {
            var itemsListCount = itemsList.Count();
            item.itemId = 1000 + 1 + itemsListCount;
            itemsList.Add(item);
            return Ok(item);
        }

        //Get Specific Item
        [HttpGet("getItem/{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            try
            {
                var item = itemsList.First(item => item.itemId == id);
                return Ok(item);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        //Update Item
        [HttpPut("updateItem")]
        public ActionResult<Item> UpdateItem(Item item)

        {
            try
            {
                foreach (var objeto in itemsList)
                {
                    if (objeto.itemId == item.itemId)
                    {

                        objeto.itemName = item.itemName;
                        objeto.itemType = item.itemType;
                        objeto.description = item.description;
                        objeto.quantity = item.quantity;
                        objeto.userId = item.userId;

                    }

                }
                return Ok(item);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        [HttpDelete("deleteItem/{id}")]
        public ActionResult<List<Item>> DeleteItem(int id)
        {
            try
            {

                foreach (var item in itemsList)
                {
                    if (item.itemId == id)
                    {
                        itemsList.Remove(item);
                    }
                }
                return Ok(itemsList);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        //Get By User
        [HttpGet("itemByUser/{userId}")]
        public ActionResult<List<Item>> GetItemByUser(int userId)
        {
            try
            {
                List<Item> listByUser = new List<Item>();
                foreach (var item in itemsList)
                {
                    if (item.userId == userId)
                    {
                        listByUser.Add(item);
                    }
                }
                return Ok(listByUser);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        //Get Item By Department
        [HttpGet("itemByDepartment/{departmentType}")]
        public ActionResult<List<Item>> ItemByDepartmentName(DepartmentType departmentType)
        {
            try
            {
                List<Item> listByDepartment = new List<Item>();
                foreach (var item in itemsList)
                {
                    if (item.itemType == departmentType)
                    {
                        listByDepartment.Add(item);
                    }
                }
                return Ok(listByDepartment);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}
