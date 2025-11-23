using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Interfaces.Services
{
    public interface IRecomendationService
    {
        Task<List<Course>> GetRecomendation(User user);
    }
}
