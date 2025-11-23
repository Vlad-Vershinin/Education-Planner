using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Fullname { get; set; }
        public DateOnly RoadEnd { get; set; }

        public UserDto() { }

        public UserDto(Guid id, string login, string fullname, DateOnly roadEnd)
        {
            Id = id;
            Login = login;
            Fullname = fullname;
            RoadEnd = roadEnd;
        }

        public UserDto(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Fullname = user.Fullname;
            RoadEnd = user.RoadEnd;
        }
    }
}
