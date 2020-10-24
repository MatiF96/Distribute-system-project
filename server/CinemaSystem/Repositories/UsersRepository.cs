using CinemaSystem.Database;
using CinemaSystem.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystem.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CinemaDbContext _ctx;

        public UsersRepository(CinemaDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return result.Entity;
        }

        public Task<User> EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _ctx.Users.SingleOrDefaultAsync(u => u.UserLogin == username);
        }
    }
}
