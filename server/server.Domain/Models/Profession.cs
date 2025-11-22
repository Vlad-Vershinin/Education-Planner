using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Relevance { get; set; }
        public List<Course> Courses { get; set; }
        public List<Skill> Skills { get; set; }

        public Profession()
        {
        }

        public Profession(int id, string name, string description, double relevance)
        {
            Id = id;
            Name = name;
            Description = description;
            Relevance = relevance;
        }
    }
}
