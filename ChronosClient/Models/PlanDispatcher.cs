using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosClient.Models
{
    public class PlanDispatcher
    {
        public int PlanDispatcherId { get; set; }
        public int UserId { get; set; }
        public int PlanId { get; set; }
        public DateTime? AssignedAt { get; set; }
    }
}
