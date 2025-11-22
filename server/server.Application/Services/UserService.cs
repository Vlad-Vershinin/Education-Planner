using server.Domain.Interfaces.Repositories;
using server.Domain.Interfaces.Services;
using server.Domain.DTOs;
using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public async Task<UserDto> AuthorizeAsync(string login, string password)
        {
            User user = await _userRepository.GetUserByLogin(login);
            UserDto dto = new UserDto();
            return dto;
        }
    }
}
