using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using ChronosClient.Screens.Windows.Popups;
using System.Net;
using System.Net.Http.Headers;
using ChronosClient.Models.Auth;




namespace ChronosClient.Screens.Windows
{
    /// <summary>
    /// Interaction logic for DashboardScreen.xaml
    /// </summary>
    public partial class DashboardScreen : Window
    {
        static HttpClient client = new HttpClient();
        DashboardHomeScreen dashboardHomeScreen;
        UserAuthResponse userAuth;
        static async Task<HttpResponseMessage> LoginJwtAsync(AuthenticateJwtRequest userAuthJwtReq)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "auth/login/jwt", userAuthJwtReq);

            return response;
        }

        private async Task<UserAuthResponse> SetLoggedInUserAuthResponse(string jwt)
        {
            AuthenticateJwtRequest userAuthJwtReq = new AuthenticateJwtRequest
            {
                jwt = jwt
            };
            var response = await LoginJwtAsync(userAuthJwtReq);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }
            UserAuthResponse userLoggedIn = await response.Content.ReadAsAsync<UserAuthResponse>();
            return userLoggedIn;
        }

        private async void initializeUserLoggedIn(string jwt)
        {
            userAuth = await SetLoggedInUserAuthResponse(jwt);
            if (userAuth != null)
            {
                dashboardHomeScreen = new DashboardHomeScreen(userAuth);
                dashboardFrame.Content = dashboardHomeScreen;
            }
        }

        public DashboardScreen(UserAuthResponse userAuth)
        {
            this.userAuth = userAuth;
            InitializeComponent();
            dashboardHomeScreen = new DashboardHomeScreen(userAuth);
            dashboardFrame.Content = dashboardHomeScreen;
        }
        public DashboardScreen(string jwt)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            initializeUserLoggedIn(jwt);
        }

        private void new_plan_button_Click(object sender, RoutedEventArgs e)
        {
            if (userAuth != null)
            {
                NewPlanScreen planScreen = new NewPlanScreen(userAuth);
                if (!planScreen.ShowDialog() == true)
                {
                    dashboardHomeScreen.initializePlans(userAuth.UserId);
                }
            }
        }

        private void profile_button_Click(object sender, RoutedEventArgs e)
        {
            dashboardFrame.Content = dashboardHomeScreen;
        }
    }
}
