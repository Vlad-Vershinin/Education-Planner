using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get { return $"{SurName} {FirstName} {LastName}".Trim(); } }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();
        public string Login { get; set; }
        public Course CurrentCourse { get; set; } // Ярик добавил.
    }
}
