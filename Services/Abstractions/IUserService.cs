using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Dto;
using WebProject.Entities;

namespace WebProject.Services.Abstractions
{
    public interface IUserService
    {
        UserDto CreateUser(UserDto userDto);
        UserDto GetUserById(int id);
    }
}