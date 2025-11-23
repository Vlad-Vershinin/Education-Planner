using server.Domain.Interfaces.Services;
using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Services
{
    public class RecomendationService : IRecomendationService
    {
        private readonly ICourseService _courseService;

        public RecomendationService(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<List<Course>> GetRecomendation(User user)
        {
            int perfectHours = user.ProfessionChosen.Courses.Select(course => course.Hours).Sum();
            int userDaysLeft = Convert.ToInt32(perfectHours / user.HoursPerDay() + 1);
            double timeCoef = (user.DaysLeft() - userDaysLeft) / user.DaysLeft() + 1;

            List<Course> courses = user.ProfessionChosen.Courses
                .OrderByDescending(course => course.Skills.Except(user.SkillsHave).Select(skill => skill.Level).Sum() / (course.Hours * timeCoef + 0.0001)).ToList();

            return courses;
        }
    }
}
