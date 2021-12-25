using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosClient.Models
{
    public class EmailModel
    {
        [Required]
        public string toname { get; set; }
        [Required, EmailAddress]
        public string toemail { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string message { get; set; }
    }
}
