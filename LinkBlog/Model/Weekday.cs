using System.ComponentModel.DataAnnotations;
using System;

namespace LinkBlog.Model
{
    public class Weekday
    {
        [Key]
        public Guid WeekdayId { get; set; }
        public Guid VisitorId { get; set; }
        public string Day { get; set; }
    }
}
