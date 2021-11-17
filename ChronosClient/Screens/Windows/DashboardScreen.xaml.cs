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

namespace ChronosClient.Screens.Windows
{
    /// <summary>
    /// Interaction logic for DashboardScreen.xaml
    /// </summary>
    public partial class DashboardScreen : Window
    {
        public DashboardScreen(UserAuthResponse userAuth) : base()
        {
            //dashboardFrame.Content = new DashboardHomeScreen(userAuth);
        }
        public DashboardScreen()
        {
            InitializeComponent();
            UserAuthResponse userAuth = new UserAuthResponse
            {
                UserId = 14,
                FirstName = "Florin",
                LastName = "Cabaua",
                DateOfBirth = DateTime.Parse("2000-07-24T00:00:00"),
                CreatedAt = DateTime.Parse("2021-11-15T19:41:47.33"),
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE0IiwibmJmIjoxNjM3MTY0MzYwLCJleHAiOjE2Mzc3NjkxNjAsImlhdCI6MTYzNzE2NDM2MH0.T7tBkidkzFXAmqwQxYmqT-N_5Xc-vYM81aDBcg7KLiM"
            };
            dashboardFrame.Content = new DashboardHomeScreen(userAuth);
        }

        private void new_plan_button_Click(object sender, RoutedEventArgs e)
        {
            NewPlanScreen planScreen = new NewPlanScreen();
            planScreen.ShowDialog();
        }
    }
}
