using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.DTOs
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Hours { get; set; }

        public CourseDto() { }

        public CourseDto(Guid id, string name, string description, string imagePath, int hours)
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            Hours = hours;
        }

        public CourseDto(Course course)
        {
            Id = course.Id;
            Name = course.Name;
            Description = course.Description;
            ImagePath = course.ImagePath;
            Hours = course.Hours;
        }
    }
}
