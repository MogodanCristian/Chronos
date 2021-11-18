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
using System.Windows.Shapes;
using ChronosClient.Models;
using ChronosClient.Screens.Pages;
using ChronosClient.Views;

namespace ChronosClient.Screens.Windows.Popups
{
    /// <summary>
    /// Interaction logic for NewBucketPopup.xaml
    /// </summary>
    public partial class NewBucketPopup : Window
    {
        static HttpClient client = new HttpClient();
        int planSelectedId;
        static bool isClient = false;
        public string m_BucketName { get; set; }
        public NewBucketPopup(string token, int planId)
        {
            InitializeComponent();
            planSelectedId = planId;
            if (!isClient)
            {
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                isClient = true;
            }
        }

        static async Task<HttpResponseMessage> CreateBucketAsync(int PlanId, BucketCreateModel bucket)
        {
            HttpResponseMessage httpResponse = await client.PostAsJsonAsync($"buckets/{PlanId}", bucket);
            return httpResponse;
        }

        private async void create_bucket_Click(object sender, RoutedEventArgs e)
        {
            if (bucket_name.Text.Length == 0)
            {
                MessageBox.Show("You cannot leave the field empty!", "Error");
                return;
            }
            else
            {
                m_BucketName = bucket_name.Text;
                BucketCreateModel bucket = new BucketCreateModel
                {
                    Title = m_BucketName
                };
                var response = await CreateBucketAsync(planSelectedId, bucket);

                string mesg = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Cannot create bucket!!", "Error");
                }
            }
            this.Close();
        }
    }
}