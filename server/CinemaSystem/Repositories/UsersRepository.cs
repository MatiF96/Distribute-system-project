using CinemaSystem.Database;
using CinemaSystem.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await GetById(userId);
            if (user == null) return false;
            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<User> EditUser(User user)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<IList<User>> GetAll()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User> GetById(int userId)
        {
            return await _ctx.Users.FindAsync(userId);
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _ctx.Users.SingleOrDefaultAsync(u => u.UserLogin == username);
        }


    }
}
