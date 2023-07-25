using AutoMapper;
using Microsoft.Extensions.Options;
using WebProject.Dto;
using WebProject.Entities;

namespace WebProject
{
    public class AutoMapperProfile : Profile // automapper will look for all dirived classes of Profile and add to application
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}