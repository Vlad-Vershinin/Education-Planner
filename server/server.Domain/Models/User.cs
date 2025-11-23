using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateOnly RoadEnd { get; set; }
        public Profession ProfessionChosen { get; set; }
        public List<CourseTaken> CoursesTaken { get; set; }
        public List<LeveledSkill> SkillsHave { get; set; }

        public User() { }

        public User(Guid id, string login, string password, string fullname)
        {
            Id = id;
            Login = login;
            Password = password;
            Fullname = fullname;
        }

        public double HoursPerDay()
        {
            DateTime dayStarted = (new DateOnly(RoadEnd.Year - 2, RoadEnd.Month, RoadEnd.Day)).ToDateTime(new TimeOnly());
            int hours = Convert.ToInt32(CoursesTaken.Select(course => course.Course.Hours * course.Progress).Sum());
            return hours / DateTime.Today.Subtract(dayStarted).Days;
        }

        public int DaysLeft()
        {
            return RoadEnd.ToDateTime(new TimeOnly()).Subtract(DateTime.Today).Days;
        }
    }
}
