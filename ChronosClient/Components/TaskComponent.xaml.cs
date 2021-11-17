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
        public static readonly DependencyProperty TaskDescriptionProperty =
            DependencyProperty.Register("TaskDescription", typeof(string), typeof(TaskComponent), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty TaskStartDateProperty =
            DependencyProperty.Register("TaskStartDate", typeof(string), typeof(TaskComponent), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty TaskEndDateProperty =
            DependencyProperty.Register("TaskEndDate", typeof(string), typeof(TaskComponent), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty TaskPriorityProperty =
            DependencyProperty.Register("TaskPriority", typeof(string), typeof(TaskComponent), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty TaskAssignedToProperty =
            DependencyProperty.Register("TaskAssignedTo", typeof(string), typeof(TaskComponent), new PropertyMetadata(string.Empty));

        public TaskComponent()
        {
            InitializeComponent();
        }

        public string TaskTitle
        {
            get { return (string)GetValue(TaskTitleProperty); }
            set { SetValue(TaskTitleProperty, value); }
        }
        public string TaskDescription
        {
            get { return (string)GetValue(TaskTitleProperty); }
            set { SetValue(TaskDescriptionProperty, value); }
        }
        public string TaskStartDate
        {
            get { return (string)GetValue(TaskTitleProperty); }
            set { SetValue(TaskStartDateProperty, value); }
        }
        public string TaskEndDate
        {
            get { return (string)GetValue(TaskTitleProperty); }
            set { SetValue(TaskEndDateProperty, value); }
        }
        public string TaskPriority
        {
            get { return (string)GetValue(TaskTitleProperty); }
            set { SetValue(TaskPriorityProperty, value); }
        }
        public string TaskAssignedTo
        {
            get { return (string)GetValue(TaskTitleProperty); }
            set { SetValue(TaskAssignedToProperty, value); }
        }
    }
}