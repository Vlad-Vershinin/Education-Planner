using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();
        public string Login { get; set; }
    }
}
