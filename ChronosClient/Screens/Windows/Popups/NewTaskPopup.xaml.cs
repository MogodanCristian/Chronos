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
using System.Windows.Shapes;

namespace ChronosClient.Screens.Windows.Popups
{
    /// <summary>
    /// Interaction logic for NewTaskPopup.xaml
    /// </summary>
    public partial class NewTaskPopup : Window
    {
        public NewTaskPopup()
        {
            InitializeComponent();
            ComboBoxItem low = new ComboBoxItem();
            ComboBoxItem medium = new ComboBoxItem();
            ComboBoxItem high = new ComboBoxItem();
            low.Content = "Low";
            medium.Content = "Medium";
            high.Content = "High";
            task_priority.Items.Add(low);
            task_priority.Items.Add(medium);
            task_priority.Items.Add(high);
        }

        public String m_Title { get; set; }
        public String m_Description { get; set; }
        public DateTime? m_EndDate { get; set; }
        public String m_Priority { get; set; }

        private void create_task_Click(object sender, RoutedEventArgs e)
        {
            if (task_name.Text.Length == 0)
            {
                MessageBox.Show("You cannot leave the field empty!", "Error");
                return;
            }
            else if (task_priority.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a priority");
                return;
            }

            else
            {
                m_Title = task_name.Text;
                m_Description = task_description.Text;
                m_Priority = task_priority.SelectedValue.ToString();
                m_EndDate = task_end_date.SelectedDate;

            }
            this.Close();
        }
    }
}