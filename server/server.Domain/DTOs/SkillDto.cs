using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Domain.Models;

namespace server.Domain.DTOs
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SkillDto() { }

        public SkillDto(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public SkillDto(Skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Description = skill.Description;
        }
    }
}
