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
        int PlanSelectedId;
        string jwtToken;

        static async Task<HttpResponseMessage> GetBucketsForPlanAsync(int PlanId)
        {
            HttpResponseMessage response = await client.GetAsync($"buckets/{PlanId}");
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
        public async void initializeBuckets(int PlanId)
        {
            BucketPanelView.clearBuckets();
            List<Bucket> bucketItems = await GetBucketItems(PlanId);
            if (bucketItems != null)
            {
                foreach (Bucket bucket in bucketItems)
                {
                    BucketPanelView.AddBucket(bucket.Title);
                }
            }
        }
        public PlanScreen(string token, int PlanId)
        {
            PlanSelectedId = PlanId;
            jwtToken = token;
            if(!clientExists)
            {
                InitializeComponent();
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                clientExists = true;
            }
            initializeBuckets(PlanSelectedId);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewBucketPopup newBucketPopup = new NewBucketPopup(jwtToken,PlanSelectedId);
            if (!newBucketPopup.ShowDialog() == true)
            {
                initializeBuckets(PlanSelectedId);
            }
        }

    }
}