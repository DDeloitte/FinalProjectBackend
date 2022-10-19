using AutoMapper;
using Final_project_webapi.Data;
using Final_project_webapi.Dtos;
using Final_project_webapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Final_project_webapi.Services.UserService
{
    public class ItemService : IItemService
    {
        //Variables for data injection sqlite and using AutoMapper
        private readonly DataContext context;
        private readonly IMapper mapper;

        //Constructors for data injection and automapper
        public ItemService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<GetItemDto>> Add(AddItemDto item)
        {
            var serviceResponse = new ServiceResponse<GetItemDto>();
            try
            {
                //var itemsListCount = context.Items.Count();
                //item.itemId = 1000 + 1 + itemsListCount;
                Item addItem = mapper.Map<Item>(item);
                context.Add(addItem);
                await context.SaveChangesAsync();

                serviceResponse.Data = mapper.Map<GetItemDto>(addItem);
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            try
            {
                Item item = await context.Items.FirstAsync(i => i.itemId == id);
                context.Remove(item);
                await context.SaveChangesAsync();
                serviceResponse.Data = context.Items.Select(i => mapper.Map<GetItemDto>(i)).ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            var dbItem = await context.Items.ToListAsync();
            try
            {
                serviceResponse.Data = dbItem.Select(i => mapper.Map<GetItemDto>(i)).ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Error = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetItemDto>> GetItemById(int id)
        {
            var serviceResponse = new ServiceResponse<GetItemDto>();
            var itemById = await context.Items.FirstOrDefaultAsync(i => i.itemId == id);
            serviceResponse.Data = mapper.Map<GetItemDto>(itemById);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> GetItemByUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            var dbItems = await context.Items.Where(item => item.userId == id).ToListAsync();
            serviceResponse.Data = mapper.Map<List<GetItemDto>>(dbItems);

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetItemDto>>> ItemByDepartmentName(DepartmentType departmentType)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            var itemByDepartment = await context.Items.Where(i => i.itemType ==departmentType).ToListAsync();
            serviceResponse.Data = mapper.Map<List<GetItemDto>>(itemByDepartment);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetItemDto>> UpdateItem(UpdateItemDto item)
        {
            var serviceResponse = new ServiceResponse<GetItemDto>();
            try
            {
                var itemUpdate = await context.Items.FirstOrDefaultAsync(i => i.itemId == item.itemId);

                mapper.Map(item, itemUpdate);
                await context.SaveChangesAsync();

                serviceResponse.Data = mapper.Map<GetItemDto>(itemUpdate);
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
