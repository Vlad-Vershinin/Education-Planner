using server.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace server.Domain.Models
{
    public class LeveledSkill
    {
        public Guid CourseId { get; set; }
        public Guid SkillId { get; set; }
        public int Level { get; set; }

        public Course Course { get; set; }
        public Skill Skill { get; set; }
        public List<LeveledSkill> LeveledSkills { get; set; }
        public LeveledSkill() { }

        public LeveledSkill(LeveledSkillDto skill)
        {
            SkillId = skill.Id;
            Skill.Name = skill.Name;
            Skill.Description = skill.Description;
            Level = skill.Level;
        } 

        public LeveledSkill(Skill skill, int level)
        {
            Skill = skill;
            Level = level;
        }
    }
}
