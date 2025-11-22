using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int ParentId { get; set; }


        public List<Skill> Children { get; set; }
        public List<Profession> Profession { get; set; }
        public List<Course> Courses { get; set; }

        public Skill() { }

        public Skill(Guid id, string name, string description, int x, int y, int z)
        {
            Id = id;
            Name = name;
            Description = description;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
