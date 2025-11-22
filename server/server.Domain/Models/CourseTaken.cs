using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Models
{
    public class CourseTaken
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }

        public Course Course { get; set; }
        public double Progress { get; set; } // [0; 1]

        public CourseTaken() { }

        public CourseTaken(Course course, double progress)
        {
            Course = course;
            Progress = progress;
        }
    }
}
