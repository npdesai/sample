using Sample.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IUserService
    {
        Task<Guid> AddUser(AddUserDto addUser);
        Task<bool> UpdateUser(UpdateUserDto updateUser);
        Task<bool> DeleteUser(Guid userId);
        Task<List<UserDto>> GetUsers(SearchDto search);
    }
}
