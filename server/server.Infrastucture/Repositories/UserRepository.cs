using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using server.Persistence;
using server.Domain.Models;
using System.Runtime.Intrinsics.X86;
using server.Domain.Interfaces.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Reflection.Metadata.Ecma335;

namespace server.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) { 
            _context = context; 
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> UserExist(int id)
        {
            return await _context.User.FindAsync(id) != null ? true : false;
        }
        public async Task<bool> UserExist(string login)
        {
            return await _context.User.FindAsync(login) != null ? true : false;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.User.FindAsync(id);
        }
        public async Task<User> GetUserByLogin(string login)
        {
            return await _context.User.FindAsync(login);
        }

    }
    
}
