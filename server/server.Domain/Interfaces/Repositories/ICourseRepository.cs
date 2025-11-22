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
        Task<Course> GetCourse(int id);
        Task<List<Profession>> GetCourseProfessions(int id);
        Task<List<LeveledSkill>> GetCourseSkills(int id);
    }
}
