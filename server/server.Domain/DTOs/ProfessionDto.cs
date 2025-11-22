using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.DTOs
{
    public class ProfessionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Relevance { get; set; }

        public ProfessionDto() { }

        public ProfessionDto(Guid id, string name, string description, double relevance)
        {
            Id = id;
            Name = name;
            Description = description;
            Relevance = relevance;
        }

        public ProfessionDto(Profession profession)
        {
            Id = profession.Id;
            Name = profession.Name;
            Description = profession.Description;
            Relevance = profession.Relevance;
        }
    }
}
