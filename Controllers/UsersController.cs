using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProject.Dto;
using WebProject.Services.Abstractions;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public UserDto GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost()]
        public UserDto CreateUser([FromBody] UserDto userDto)
        {
            return _userService.CreateUser(userDto);
        }
    }
}