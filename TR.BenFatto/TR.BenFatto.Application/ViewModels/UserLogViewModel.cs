using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.ViewModels
{
    public class UserLogViewModel
    {
        public int Id { get; set; }

        [MinLength(7)]
        [MaxLength(15)]
        [DisplayName("IP Adress")]
        [Required(ErrorMessage = "Please inform the IP Adress.")]
        public string IpAdress { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Please inform the Date.")]
        [DataType(DataType.Date)]
        public DateTime DateFromLog { get; set; }

        [DisplayName("Hour")]
        [Required(ErrorMessage = "Please inform the Hour.")]
        [DataType(DataType.Time)]
        public TimeSpan LogHour { get; set; }

        [DataType(DataType.DateTime)]
        public string NormalizedDate { get; set; }

        [DisplayName("User-Agent")]
        [Required(ErrorMessage = "Please inform the User-Agent.")]
        public string UserAgent { get; set; }

        public string NormalizedLog { get; set; }
    }
}
