using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.DTOs
{
    public class LeveledSkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        public LeveledSkillDto() { }

        public LeveledSkillDto(Guid id, string name, string description, int level)
        {
            Id = id;
            Name = name;
            Description = description;
            Level = level;
        }

        public LeveledSkillDto(LeveledSkill leveledSkill)
        {
            Id = leveledSkill.Skill.Id;
            Name = leveledSkill.Skill.Name;
            Description = leveledSkill.Skill.Description;
            Level = leveledSkill.Level;
        }
    }
}
