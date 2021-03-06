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
using ChronosClient.Components;

namespace ChronosClient.Views
{
    /// <summary>
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class TaskView : UserControl
    {
        List<TaskComponent> m_tasks;
        public TaskView()
        {
            InitializeComponent();
            m_tasks = new List<TaskComponent>();
        }
        public void AddTask(int taskId, string taskTitle, string taskDescription, DateTime? dateTime, string priority, string token)
        {

            TaskComponent newTask = new TaskComponent(token)
            {
                TaskId = taskId,
                TaskTitle = taskTitle,
                TaskDescription = taskDescription,
                TaskEndDate = dateTime.ToString(),
                TaskPriority = priority,

                Margin = new Thickness(10)
            };
            foreach(var t in m_tasks)
            {
                if(t.TaskId == newTask.TaskId)
                {
                    return;
                }
            }
            m_tasks.Add(newTask);
            tasks.Children.Add(newTask);
        }
    }
}