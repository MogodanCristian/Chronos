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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using ChronosClient.Models;
using ChronosClient.Screens.Pages;
using ChronosClient.Screens.Windows.Popups;

namespace ChronosClient.Components
{
    /// <summary>
    /// Interaction logic for BucketComponent.xaml
    /// </summary>
    public partial class BucketComponent : System.Windows.Controls.UserControl
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
        public int UserId;
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
        static async Task<HttpResponseMessage> CreateTaskAsync(TaskCreateModel task)
        {
            HttpResponseMessage httpResponse = await client.PostAsJsonAsync("Tasks", task);
            return httpResponse;
        }
        public async static void parseWithXmlReader(string filename,int userID, int bucketID, RoutedEventArgs e)
        {
            double totalOrderCost = 0.0, totalTransportCost = 0.0, avgTransportCost = 0.0;
            int nr_comenzi = 0;

            using (var xmlReader = new XmlTextReader(filename))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.Name)
                        {
                            case "Task":
                                string title = xmlReader.GetAttribute("Title");
                                string description = xmlReader.GetAttribute("Description");
                                DateTime endDate = Convert.ToDateTime(xmlReader.GetAttribute("EndDate"));
                                string priority = xmlReader.GetAttribute("Priority");
                                int priority_in_int=0;
                                if(priority == "High")
                                {
                                    priority_in_int = 2;
                                }
                                else if(priority == "Medium")
                                {
                                    priority_in_int=1;
                                }
                                else if(priority == "Low")
                                {
                                    priority_in_int = 0;
                                }
                                TaskCreateModel task = new TaskCreateModel
                                {
                                    Title = title,
                                    Description = description,
                                    StartDate = null,
                                    EndDate = endDate,
                                    Priority = priority_in_int,
                                    CreatedAt = null,
                                    Progress = 0,
                                    BucketId =bucketID,
                                    UserId = userID
                                };
                                var response=await CreateTaskAsync(task);
                                PlanScreen.handler.OnChanged(e);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            avgTransportCost = totalTransportCost / nr_comenzi;
            Console.WriteLine($"Total order cost:\t{totalOrderCost}");
            Console.WriteLine($"Total transport cost:\t{totalTransportCost}");
            Console.WriteLine($"Average transport cost:\t{avgTransportCost}");
        }
        private void load_task_from_file_Click(object sender, RoutedEventArgs e)
        {
            string filePath;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML Files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    parseWithXmlReader(filePath,UserId,BucketId,e);
                }
            }
        }
    }
}