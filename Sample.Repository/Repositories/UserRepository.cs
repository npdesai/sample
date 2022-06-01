using Microsoft.EntityFrameworkCore;
using Sample.Models.Entities;
using Sample.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SampleDBContext _dbContext;

        public UserRepository(SampleDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddUser(User user)
        {
            try
            {
                user.CreatedAt = DateTime.Now;
                await _dbContext.Users.AddAsync(user);

                await _dbContext.SaveChangesAsync();

                return user.UserId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                user.UpdatedAt = DateTime.Now;
                _dbContext.Entry(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                _dbContext.Remove(user).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<User>> GetUsers(string email, string phone)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone))
            {
                return await _dbContext.Users
                                        .Where(u => u.Email.ToLower() == email.ToLower() || u.Phone == phone)
                                        .ToListAsync();
            }
            else
            {
                return await _dbContext.Users.ToListAsync();
            }
        }

        public async Task<User> GetUserByUserId(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<bool> IsUserEmailExist(string email, Guid? userId = null)
        {
            if (userId != null)
            {
                return await _dbContext.Users.AnyAsync(u => u.Email.ToLower() == email.Trim().ToLower() && u.UserId != userId);
            }

            return await _dbContext.Users.AnyAsync(u => u.Email.ToLower() == email.Trim().ToLower());
        }
    }
}
