using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Common;
using Sample.Common.StaticHelpers;
using Sample.Models.DTOs;
using Sample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.Users.AddUser)]
        [ProducesResponseType(typeof(ResponseDto<Guid?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDto<Guid?>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDto<Guid?>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUser(AddUserDto user)
        {
            ResponseDto<Guid?> response = new();

            try
            {
                Guid userId = await _userService.AddUser(user);
                response.Data = userId;
                response.Success = true;
                response.Message = Messages.MSG_USER_ADDED;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Data = null;
                response.Success = false;

                return BadRequest(response);
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut(ApiRoute.Users.UpdateUser)]
        [ProducesResponseType(typeof(ResponseDto<bool?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDto<bool?>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDto<bool?>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            ResponseDto<bool?> response = new();

            try
            {
                bool isUpdated = await _userService.UpdateUser(user);
                response.Data = isUpdated;
                response.Success = true;
                response.Message = Messages.MSG_USER_UPDATED;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Data = null;
                response.Success = false;

                return BadRequest(response);
            }
        }

        /// <summary>
        /// Delete User by UserId
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpDelete(ApiRoute.Users.DeleteUser)]
        [ProducesResponseType(typeof(ResponseDto<bool?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDto<bool?>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDto<bool?>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(Guid userid)
        {
            ResponseDto<bool?> response = new();

            try
            {
                bool isDeleted = await _userService.DeleteUser(userid);
                response.Data = isDeleted;
                response.Success = true;
                response.Message = Messages.MSG_USER_DELETED;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Data = null;
                response.Success = false;

                return BadRequest(response);
            }
        }

        /// <summary>
        /// Search Users by Email or Phone
        /// </summary>
        /// <remarks>
        /// SortField = Field name to be sort, 
        /// SortOrder Asc = 0, Desc = 1
        /// </remarks>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.Users.GetUsers)]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers(SearchDto search)
        {
            ResponseDto<List<UserDto>> response = new();

            try
            {
                List<UserDto> users = await _userService.GetUsers(search);
                response.Data = users;
                response.Success = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;

                return BadRequest(response);
            }
        }
    }
}
