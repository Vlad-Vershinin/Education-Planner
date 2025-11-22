using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Models
{
    public class Article
    {
        public int Id { get; set; }
       public string Title { get; set; }
        public string Body { get; set; }
        public string Content { get; set; }
        public string ContentUrl { get; set; }
    }
}
