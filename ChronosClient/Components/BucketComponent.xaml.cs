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

namespace ChronosClient.Components
{
    /// <summary>
    /// Interaction logic for BucketComponent.xaml
    /// </summary>
    public partial class BucketComponent : UserControl
    {
        public static readonly DependencyProperty BucketTitleProperty =
            DependencyProperty.Register("BucketTitle", typeof(string), typeof(BucketComponent), new PropertyMetadata(string.Empty));

        public string BucketTitle
        {
            get { return (string)GetValue(BucketTitleProperty); }
            set { SetValue(BucketTitleProperty, value); }
        }

        public BucketComponent()
        {
            InitializeComponent();
        }
    }
}
