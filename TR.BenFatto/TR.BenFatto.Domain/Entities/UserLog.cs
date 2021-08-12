using System;

namespace TR.BenFatto.Domain.Entities
{
    public class UserLog
    {
        public int Id { get; set; }
        public string IpAdress { get; set; }
        public DateTime DateFromLog { get; set; }
        public string NormalizedDate { get; set; }
        public TimeSpan LogHour { get; set; }
        public string UserAgent { get; set; }
        public string NormalizedLog { get; set; }
    }
}
