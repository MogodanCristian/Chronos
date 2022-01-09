using ChronosClient.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChronosClient.Models;

namespace ChronosClient.Views
{
    /// <summary>
    /// Interaction logic for BucketView.xaml
    /// </summary>
    /// 
    public partial class BucketView : UserControl
    {
        List<BucketComponent> m_buckets;
        public BucketView()
        {
            InitializeComponent();
            m_buckets = new List<BucketComponent>();
        }
        public void AddBucket(string bucketTitle, int bucketId, int userId, string token)
        {
            BucketComponent newBucket = new BucketComponent(userId, token)
            {
                BucketId = bucketId,
                BucketTitle = bucketTitle,
                Margin = new Thickness(10)
            };

            foreach(var t in m_buckets)
            {
                if(t.BucketId == newBucket.BucketId)
                {
                    return;
                }
            }

            m_buckets.Add(newBucket);
            buckets.Children.Add(newBucket);
        }

        public void AddTaskToBucketComponent(int bucketId, TasksForPlanResponse task)
        {
            foreach(BucketComponent bucketComponent in buckets.Children)
            {
                if(bucketComponent.BucketId == bucketId)
                {
                    bucketComponent.add_a_new_task(task);
                    break;
                }
            }
        }
        public void clearBuckets()
        {
            if (buckets.Children.Count > 0)
            {
                m_buckets.Clear();
                buckets.Children.Clear();
            }
        }
    }
}
