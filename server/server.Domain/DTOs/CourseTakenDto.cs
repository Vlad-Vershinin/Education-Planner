using server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.DTOs
{
    public class CourseTakenDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Hours { get; set; }
        public double Progress { get; set; }

        public CourseTakenDto() { }

        public CourseTakenDto(Guid id, string name, string description,
            string imagePath, int hours, double progress)
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            Hours = hours;
            Progress = progress;
        }

        public CourseTakenDto(CourseTaken courseTaken)
        {
            Id = courseTaken.Course.Id;
            Name = courseTaken.Course.Name;
            Description = courseTaken.Course.Description;
            ImagePath = courseTaken.Course.ImagePath;
            Hours = courseTaken.Course.Hours;
            Progress = courseTaken.Progress;
        }
    }
}
