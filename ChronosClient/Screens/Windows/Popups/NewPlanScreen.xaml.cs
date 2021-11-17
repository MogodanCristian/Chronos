using ChronosClient.Models;
using ChronosClient.Screens.Pages;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;
using Application = System.Windows.Application;


namespace ChronosClient.Screens.Windows.Popups
{
    /// <summary>
    /// Interaction logic for NewPlanScreen.xaml
    /// </summary>
    public partial class NewPlanScreen : Window
    {
        static HttpClient client = new HttpClient();
        static bool clientExists = false;

        public NewPlanScreen()
        {
            InitializeComponent();
            if(!clientExists)
            {
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE0IiwibmJmIjoxNjM3MTY0MzYwLCJleHAiOjE2Mzc3NjkxNjAsImlhdCI6MTYzNzE2NDM2MH0.T7tBkidkzFXAmqwQxYmqT-N_5Xc-vYM81aDBcg7KLiM";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                clientExists = true;
            }
        }

        static async Task<HttpResponseMessage> CreatePlanAsync(int UserId, Plan plan)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"Plans/{UserId}", plan);
            return response;
        }

        private async void create_button_Click(object sender, RoutedEventArgs e)
        {
            if (inserted_name.Text.Length != 0)
            {
                Plan plan = new Plan
                {
                    Title = inserted_name.Text,
                    Description = description_inserted.Text
                };

                var response = await CreatePlanAsync(14, plan);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Cannot create plan!", "Error");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please complete the plan's name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}