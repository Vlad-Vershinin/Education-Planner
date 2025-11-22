using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Domain.DTOs;

namespace server.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> AuthorizeAsync(string login, string password);
        Task<UserDto> GetUserAsync(int id);
    }
}
