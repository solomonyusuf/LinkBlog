using System;
using System.ComponentModel.DataAnnotations;

namespace LinkBlog.Model
{
    public class LinkResponse
    {
        [Key]
        public Guid LinkResponseId { get; set; }
        public Guid VisitorId { get; set; }
        public string Response { get; set; }
        
    }
}
