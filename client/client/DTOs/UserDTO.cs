using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public ProfessionDTO? ProfessionChosen { get; set; }
        public List<CourseExtendedDTO> CoursesTaken { get; set; } = new List<CourseExtendedDTO>();
        public List<LeveledSkillDTO> SkillsHave { get; set; } = new List<LeveledSkillDTO>();
    }
}
