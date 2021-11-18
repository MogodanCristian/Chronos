using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosClient.Models
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    public class BucketList: List<Bucket>
    {
        public event ChangedEventHandler Changed;
        public virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }
    }
}
