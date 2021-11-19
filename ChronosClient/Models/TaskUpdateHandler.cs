using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosClient.Models
{
    public delegate void ChangedEventHandlerTasks(object sender, EventArgs e);
   public class TaskUpdateHandler
    {
        public event ChangedEventHandlerTasks Changed;
        public virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }
    }
}
