using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using ChronosClient.Models;

namespace ChronosClient.Screens.Windows.Popups
{
    /// <summary>
    /// Interaction logic for NewTaskPopup.xaml
    /// </summary>
    public partial class NewTaskPopup : Window
    {
        int bucketSelectedId;
        int userID;
        public NewTaskPopup(string token, int bucketId, int userId)
        {
            InitializeComponent();
            bucketSelectedId = bucketId;
            userID = userId;
            if (!isClient)
            {
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                isClient = true;
            }
        }

        public String m_Title { get; set; }
        public String m_Description { get; set; }
        public DateTime? m_EndDate { get; set; }
        public String m_Priority { get; set; }

        static HttpClient client = new HttpClient();

        static bool isClient = false;
        static async Task<HttpResponseMessage> CreateTaskAsync(TaskCreateModel task)
        {
            HttpResponseMessage httpResponse = await client.PostAsJsonAsync("Tasks", task);
            return httpResponse;
        }

        private async void create_task_Click(object sender, RoutedEventArgs e)
        {
            if (task_name.Text.Length == 0)
            {
                MessageBox.Show("You cannot leave the name field empty!", "Error");
                return;
            }
            else if (task_priority.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a priority!");
                return;
            }
            else
            {
                TaskCreateModel task = new TaskCreateModel
                {
                    Title = task_name.Text,
                    Description = task_description.Text,
                    CreatedAt = null,
                    StartDate = null,
                    EndDate = task_end_date.SelectedDate,
                    Progress = 0,
                    Priority = task_priority.SelectedIndex,
                    BucketId = bucketSelectedId,
                    UserId = userID

                };
                var response = await CreateTaskAsync(task);
            }
            this.Close();
        }
    }
}