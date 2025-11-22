using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.DTOs
{
    public class CourseExtendedDTO
    {
        public CourseDTO Course { get; set; } = new CourseDTO();
        public int Level { get; set; }
        public double Progress { get; set; }
    }
}
