using Sample.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
        Task<List<User>> GetUsers(string email, string phone);
        Task<User> GetUserByUserId(Guid userId);
        Task<bool> IsUserEmailExist(string email, Guid? userId = null);
    }
}
