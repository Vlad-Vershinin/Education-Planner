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

namespace server.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) { 
            _context = context; 
        }

        public async Task<bool> UserExist()
        {
               return await _context.User
                .AnyAsync(u => u.Id == _context.)
        }


    }
    
}
