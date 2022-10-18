using Final_project_webapi.Models;
using System.Reflection.Metadata.Ecma335;

namespace Final_project_webapi.Services.UserService
{
    public class ItemService : IItemService
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

        public async Task<ServiceResponse<List<Item>>> Add(Item item)
        {
            ServiceResponse<List<Item>> serviceResponse = new ServiceResponse<List<Item>>();
            try
            {
                var itemsListCount = itemsList.Count();
                item.itemId = 1000 + 1 + itemsListCount;
                itemsList.Add(item);
                serviceResponse.Data = itemsList;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> DeleteItem(int id)
        {
            ServiceResponse<List<Item>> serviceResponse = new ServiceResponse<List<Item>>();
            try
            {

                foreach (var item in itemsList)
                {
                    if (item.itemId == id)
                    {
                        itemsList.Remove(item);
                    }
                }
                serviceResponse.Data = itemsList;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> GetAll()
        {
            ServiceResponse<List<Item>> serviceResponse = new ServiceResponse<List<Item>>();

            try
            {
                serviceResponse.Data = itemsList;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Item>> GetItemById(int id)
        {
            ServiceResponse<Item> serviceResponse = new ServiceResponse<Item>();
            try
            {
                var item = itemsList.First(item => item.itemId == id);
                serviceResponse.Data = item;
                return serviceResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> GetItemByUser(int id)
        {
            ServiceResponse<List<Item>> serviceResponse = new ServiceResponse<List<Item>>();
            try
            {
                List<Item> listByUser = new List<Item>();
                foreach (var item in itemsList)
                {
                    if (item.userId == id)
                    {
                        listByUser.Add(item);
                    }
                }
                serviceResponse.Data = listByUser;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> ItemByDepartmentName(DepartmentType departmentType)
        {
            ServiceResponse<List<Item>> serviceResponse = new ServiceResponse<List<Item>>();
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
                serviceResponse.Data = listByDepartment;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Item>> UpdateItem(Item item)
        {
            ServiceResponse<Item> serviceResponse = new ServiceResponse<Item>();
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
                serviceResponse.Data = item;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }
    }
}
