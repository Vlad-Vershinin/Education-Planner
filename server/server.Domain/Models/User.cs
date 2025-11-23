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
    }
}
