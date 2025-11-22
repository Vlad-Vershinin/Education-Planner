using client.Models;
using client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    public class UserService : IUserServece
    {
        public User CurrentUser { get; set; }
    }
}
