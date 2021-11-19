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
        public static readonly DependencyProperty TaskIdProperty =
            DependencyProperty.Register("TaskId", typeof(int), typeof(TaskComponent), new PropertyMetadata(0));

        static bool isClient = false;
        static HttpClient client = new HttpClient();
        static string jwtToken;
        public TaskComponent(string token)
        {
            InitializeComponent();
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
        public int TaskId
        {
            get { return (int)GetValue(TaskIdProperty); }
            set { SetValue(TaskIdProperty, value); }
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
        static async Task<HttpResponseMessage> DeleteTaskAsync(int TaskId)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent("{ TaskID:" + TaskId.ToString() + "}", Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://chronosapi.azurewebsites.net/api/Tasks")
            };
            HttpResponseMessage message = await client.SendAsync(request);
            return message;
        }
        private async void delete_task_Click(object sender, RoutedEventArgs e)
        {
            var response = await DeleteTaskAsync(TaskId);
            MessageBox.Show(response.StatusCode.ToString());
            BucketComponent.handler.OnChanged(e);
        }
    }
}