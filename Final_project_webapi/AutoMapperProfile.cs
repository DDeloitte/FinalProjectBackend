using AutoMapper;
using Final_project_webapi.Dtos;
using Final_project_webapi.Models;

namespace Final_project_webapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Item, GetItemDto>();
            CreateMap<AddItemDto, Item>();
            CreateMap<UpdateItemDto, Item>();
        }
    }
}
