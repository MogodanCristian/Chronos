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
    public partial class BucketView : UserControl
    {
        public BucketView()
        {
            InitializeComponent();
        }
        public void AddBucket(string bucketTitle, int bucketId, int userId, string token)
        {
            buckets.Children.Add(new BucketComponent(userId, token)
            {
                BucketTitle = bucketTitle,
                BucketId = bucketId,
                Margin = new Thickness(10)
            });
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
            if(buckets.Children.Count > 0)
            {
                buckets.Children.Clear();
            }
        }
    }
}
