using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using ChronosClient.Screens.Windows.Popups;

namespace ChronosClient.Screens.Pages
{
    /// <summary>
    /// Interaction logic for PlanScreen.xaml
    /// </summary>
    public partial class PlanScreen : Page
    {
        static HttpClient client = new HttpClient();
        static bool clientExists = false;
        public static BucketList m_buckets;
        int PlanSelectedId;
        string jwtToken;
        int UserId;
        static public TaskUpdateHandler handler;
        bool UserChangedText = false;

        static async Task<HttpResponseMessage> GetBucketsForPlanAsync(int PlanId)
        {
            HttpResponseMessage response = await client.GetAsync($"buckets/{PlanId}");
            return response;
        }
        static async Task<HttpResponseMessage> GetTasksForPlanAsync(int PlanId)
        {
            HttpResponseMessage response = await client.GetAsync($"Tasks/{PlanId}");
            return response;
        }
        private async Task<List<Bucket>> GetBucketItems(int PlanId)
        {
            var response = await GetBucketsForPlanAsync(PlanId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            List<Bucket> buckets = await response.Content.ReadAsAsync<List<Bucket>>();
            return buckets;
        }
     
        private async Task<List<TasksForPlanResponse>> GetTaskItems(int PlanId)
        {
            var response = await GetTasksForPlanAsync(PlanId);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            List<TasksForPlanResponse> tasksInPlan = await response.Content.ReadAsAsync<List<TasksForPlanResponse>>();
            return tasksInPlan;
        }
        public async void initializeBuckets(int PlanId)
        {
            BucketPanelView.clearBuckets();
            List<Bucket> bucketItems = await GetBucketItems(PlanId);
            if (bucketItems != null)
            {
                foreach (Bucket bucket in bucketItems)
                {
                    BucketPanelView.AddBucket(bucket.Title, bucket.BucketID,UserId, jwtToken);
                    m_buckets.Add(bucket);
                }
            }
        }
        public async void initializeTasksInBuckets(int PlanId)
        {
            BucketPanelView.clearBuckets();
            List<Bucket> bucketItems = await GetBucketItems(PlanId);
            List<TasksForPlanResponse> tasksInPlan = await GetTaskItems(PlanId);
            if (bucketItems != null)
            {
                foreach (Bucket bucket in bucketItems)
                {
                    BucketPanelView.AddBucket(bucket.Title, bucket.BucketID, UserId, jwtToken);
                    if(tasksInPlan!=null)
                    {
                        foreach (TasksForPlanResponse task in tasksInPlan)
                        {  
                             BucketPanelView.AddTaskToBucketComponent(task.BucketID, task);
                        }
                    }              
                    m_buckets.Add(bucket);
                }
            }
        }
        public PlanScreen(int UserId, string token, int PlanId)
        {
            InitializeComponent();
            member_name_search_textbox.TextChanged -= member_name_search_textbox_TextChanged;
            member_name_search_textbox.Text = "Enter name of member to add...";
            member_name_search_textbox.TextChanged += member_name_search_textbox_TextChanged;
            Panel.SetZIndex(MembersExpander, 0);
            Panel.SetZIndex(plan_screen_grid, 1);
            PlanSelectedId = PlanId;
            jwtToken = token;
            this.UserId = UserId;
            handler = new TaskUpdateHandler();
            handler.Changed += new ChangedEventHandlerTasks(TasksChanged);
            if (!clientExists)
            {
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                clientExists = true;
                m_buckets = new BucketList();
                m_buckets.Changed += new ChangedEventHandler(BucketsChanged);
            }
            initializeTasksInBuckets(PlanSelectedId);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewBucketPopup newBucketPopup = new NewBucketPopup(jwtToken, PlanSelectedId);
            if (!newBucketPopup.ShowDialog() == true)
            {
                initializeTasksInBuckets(PlanSelectedId);
            }
        }
        private void BucketsChanged(object sender, EventArgs e)
        {
            initializeTasksInBuckets(PlanSelectedId);
        }

        private void TasksChanged(object sender, EventArgs e)
        {
            ///fetch from database;
            initializeTasksInBuckets(PlanSelectedId);
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            //member_name_search_textbox.Focus();
            //member_name_search_textbox.Select(0, 0);
            Panel.SetZIndex(MembersExpander, 1);
            Panel.SetZIndex(plan_screen_grid, 0);
        }

        private void MembersExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(MembersExpander, 0);
            Panel.SetZIndex(plan_screen_grid, 1);
        }

        private void member_name_search_textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            UserChangedText = false;
            if (string.IsNullOrWhiteSpace(member_name_search_textbox.Text))
                member_name_search_textbox.Text = "Enter name of member to add...";
        }

        private void member_name_search_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string defaultText = "Enter name of member to add...";
            if(member_name_search_textbox.Text.Contains(defaultText) && UserChangedText == true )
            {
                member_name_search_textbox.Text = member_name_search_textbox.Text.Replace(defaultText, "");
                member_name_search_textbox.SelectionStart++;
            }
        }

        private void member_name_search_textbox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            member_name_search_textbox.Focus();
            member_name_search_textbox.SelectionStart = 0;
        }

        private void member_name_search_textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            UserChangedText = true;
            member_name_search_textbox.SelectionStart = 0;
        }
    }
}