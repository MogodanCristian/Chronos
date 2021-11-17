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
    /// Interaction logic for TaskComponent.xaml
    /// </summary>
    public partial class TaskComponent : UserControl
    {
        public static readonly DependencyProperty TaskTitleProperty =
            DependencyProperty.Register("TaskTitle", typeof(string), typeof(TaskComponent), new PropertyMetadata(string.Empty));
        public TaskComponent()
        {
            InitializeComponent();
        }

        public string TaskTitle
        {
            get { return (string)GetValue(TaskTitleProperty); }
            set { SetValue(TaskTitleProperty, value); }
        }
    }
}
