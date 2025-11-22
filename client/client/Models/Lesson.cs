using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Article> Content { get; set; } = new List<Article>();
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
