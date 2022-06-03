using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data;
using my_books.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersService _usersService;
        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        // End Point to Add New User
        [HttpPost("add-user")]
        public IActionResult AddUser([FromBody] UserInfoVM user)
        {
            _usersService.AddNewUser(user);
            return Ok();
        }

        // End Point to Get All Book
        [HttpGet("get-all-users")]
        public IActionResult GetUsers()
        {
            return Ok(_usersService.GetAllUsers());
        }

        // End Point to Get User By ID
        [HttpGet("get-user-by-id/{Id}")]
        public IActionResult GetUserByID(int Id)
        {
            return Ok(_usersService.GetUserById(Id));
        }

        // End Point to Delete User By ID
        [HttpDelete("delete-user-by-id/{Id}")]
        public IActionResult DeleteUserById(int Id)
        {
            _usersService.DeleteUserById(Id);
            return Ok();
        }

        // End Point to Update User By ID
        [HttpPut("update-user-by-id/{Id}")]
        public IActionResult UpdateUserByID(int Id, [FromBody] UserInfoVM user)
        {
            var updatedUser = _usersService.UpdateUserById(Id, user);
            return Ok(updatedUser);
        }
    }
}
