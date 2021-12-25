using ChronosClient.Models;
using ChronosClient.Screens.Windows;
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

namespace ChronosClient.Screens.Pages
{
    /// <summary>
    /// Interaction logic for DashboardHomeScreen.xaml
    /// </summary>
    public partial class DashboardHomeScreen : Page
    {
        static bool isAlreadyInstantiated = false;
        static HttpClient client = new HttpClient();
        UserAuthResponse user;

        static async Task<HttpResponseMessage> GetPlansForUserAsync(int UserId)
        {
            HttpResponseMessage response = await client.GetAsync($"Plans/{UserId}");
            return response;
        }
        static public UpdateHandler handler;
        public DashboardHomeScreen(UserAuthResponse userAuth)
        {
            try
            {
                user = userAuth;
                InitializeComponent();
                if(!isAlreadyInstantiated)
                {
                    client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(userAuth.Token);
                    isAlreadyInstantiated = true;
                } 
                handler = new UpdateHandler();
                handler.Changed += new ChangedEventHandlerTasks(PlansChanged);
                welcome_textblock.Text = "Welcome back, " + userAuth.FirstName + " " + userAuth.LastName + "!";
                initializePlans(userAuth.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void initializePlans(int UserId)
        {
            PlanItemsWrapPanel.clearPlanItems();
            List<Plan> planItems = await GetPlanItems(UserId);
            if (planItems != null)
            {
                foreach (Plan plan in planItems)
                {
                    PlanItemsWrapPanel.addPlanItem(plan.PlanId, plan.Title, plan.CreatedAt.ToString().Substring(0, 10), user.Token, UserId);
                }
            }
        }

        private async Task<List<Plan>> GetPlanItems(int UserId)
        {
            var response = await GetPlansForUserAsync(UserId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            List<Plan> plans = await response.Content.ReadAsAsync<List<Plan>>();
            return plans;
        }
        private void PlansChanged(object sender, EventArgs e)
        {
            initializePlans(user.UserId);
        }
    }
}