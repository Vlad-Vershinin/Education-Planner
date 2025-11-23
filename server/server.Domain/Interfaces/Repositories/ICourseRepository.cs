using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Domain.Models;

namespace server.Domain.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourse(Guid Id);
        Task<List<Profession>> GetCourseProfessions(Guid Id);
        Task<List<LeveledSkill>> GetCourseSkills(Guid Id);
    }
}
