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
        public void AddBucket(string bucketTitle, int bucketId)
        {
            buckets.Children.Add(new BucketComponent
            {
                BucketTitle = bucketTitle,
                BucketId=bucketId,
                Margin = new Thickness(10)
            });
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
