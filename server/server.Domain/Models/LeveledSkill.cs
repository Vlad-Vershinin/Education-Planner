using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Models
{
    public class LeveledSkill
    {
        public Skill Skill { get; set; }
        public int Level { get; set; }

        public LeveledSkill() { }

        public LeveledSkill(Skill skill, int level)
        {
            Skill = skill;
            Level = level;
        }
    }
}
