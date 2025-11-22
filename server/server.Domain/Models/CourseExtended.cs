using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Models
{
    // Используем только всех случаев, связанных с конкретным пользователем
    public class LeveledCourse
    {
        public Guid Id { get; set; }
        public Course Course { get; set; }
        public int Level { get; set; }
        public double Progress { get; set; }

        public LeveledCourse() { }

        public LeveledCourse(Course course, int level, double progress)
        {
            Course = course;
            Level = level;
            Progress = progress;
        }
    }
}
