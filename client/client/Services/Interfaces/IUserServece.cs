using client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services.Interfaces
{
    public interface IUserServece
    {
        Task<bool> IsUserEnrolledInCourse(int userId, int courseId);
        Task<Course>GetUserCourse(int userId);

    }
}
