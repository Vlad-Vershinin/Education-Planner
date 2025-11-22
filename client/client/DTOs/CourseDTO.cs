using client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.DTOs
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public List<SkillDTO> Skills { get; set; } = new List<SkillDTO>();
        public List<ProfessionDTO> Professions { get; set; } = new List<ProfessionDTO>();


        public Course ToModel()
        {
            return new Course
            {
                Id = Id,
                Title = Name,
                Description = Description,
                Lessons = new List<Lesson>(),
            };
        }


        public static CourseDTO FromModel(Course model)
        {
            return new CourseDTO
            {
                Id = model.Id,
                Name = model.Title ?? string.Empty,
                Description = model.Description ?? string.Empty,
                Skills = new List<SkillDTO>(),
                Professions = new List<ProfessionDTO>()
            };
        }
    }
}
