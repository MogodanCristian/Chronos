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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChronosClient.Models;
using ChronosClient.Screens.Pages;
using ChronosClient.Screens.Windows.Popups;

namespace ChronosClient.Components
{
    /// <summary>
    /// Interaction logic for BucketComponent.xaml
    /// </summary>
    public partial class BucketComponent : UserControl
    {

        public static readonly DependencyProperty BucketTitleProperty =
            DependencyProperty.Register("BucketTitle", typeof(string), typeof(BucketComponent), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty BucketIdProperty =
            DependencyProperty.Register("BucketId", typeof(int), typeof(BucketComponent), new PropertyMetadata(0));
     
        
        public string BucketTitle
        {
            get { return (string)GetValue(BucketTitleProperty); }
            set { SetValue(BucketTitleProperty, value); }
        }

        public int BucketId
        {
            get { return (int)GetValue(BucketIdProperty); }
            set { SetValue(BucketIdProperty, value); }
        }

        static HttpClient client = new HttpClient();
        static bool isClient = false;
        int UserId;
        string jwtToken;


        public BucketComponent(int UserId, string token)
        {
            InitializeComponent();
            this.UserId = UserId;
            jwtToken = token;
            if (!isClient)
            {
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(jwtToken);
                isClient = true;
            }

        }

        static async Task<HttpResponseMessage> DeleteBucketAsync(Bucket bucket)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent("{ BucketID:" + bucket.BucketID.ToString() + "}", Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://chronosapi.azurewebsites.net/api/buckets")
            };
            HttpResponseMessage message = await client.SendAsync(request);
            return message;
        }

        public void add_a_new_task(TasksForPlanResponse task)
        {
            taskView.AddTask(task.TaskID, task.Title, task.Description, task.EndDate, task.Priority.ToString(), jwtToken);
        }

        private void add_task_Click(object sender, RoutedEventArgs e)
        {
            NewTaskPopup newTaskPopup = new NewTaskPopup(jwtToken, BucketId, UserId);
            if (!newTaskPopup.ShowDialog() == true)
            {
                PlanScreen.handler.OnChanged(e);
            }
        }
        public class DeletedEventArgs : EventArgs
        {
            public string Message { get; set; }
        }
        private async void delete_bucket_Click(object sender, RoutedEventArgs e)
        {
            Bucket bucket = new Bucket { BucketID = BucketId };
            var response = await DeleteBucketAsync(bucket);
            PlanScreen.handler.OnChanged(e);
        }
    }
}