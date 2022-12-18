using System;
using System.ComponentModel.DataAnnotations;

namespace LinkBlog.Model
{
    public class Visitor
    {
        [Key]
        public Guid VisitorId { get; set; }
        public string Url { get; set; }
        public DateTime DateTime { get; set; }
        public Visitor()
        {
            DateTime = DateTime.Now;
        }
    }
}
