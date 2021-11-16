using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosClient.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public String Title { get; set; }

        public DateTime? CreatedAt { get; set; }

        public String Description { get; set; }

    }
}
