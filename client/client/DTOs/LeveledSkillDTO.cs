using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.DTOs
{
    public class LeveledSkillDTO
    {
        public SkillDTO Skill { get; set; } = new SkillDTO();
        public int Level { get; set; }
    }
}
