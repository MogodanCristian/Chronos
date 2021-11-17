using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosClient.Models.Auth
{
    public class PlanAuth
    {
        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }
    }
}
