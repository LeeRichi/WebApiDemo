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
        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(statusCode: 200)]
        public ActionResult<UserDto> GetUserById(int id)
        {
/*             var foundUser = _userService.GetUserById(id);
            if(foundUser == null)
            {
                return NotFound();
            } */
            return _userService.GetUserById(id);
        }

        [HttpPost()]
        public UserDto CreateUser([FromBody] UserDto userDto)
        {
            return _userService.CreateUser(userDto);
        }
    }
}