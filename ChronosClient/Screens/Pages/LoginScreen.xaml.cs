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
using System.Windows.Shapes;
using System.Net;
using ChronosClient.Models;
using Newtonsoft.Json;
using ChronosClient.Screens.Windows;
using System.IO;


namespace ChronosClient.Screens.Pages
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Page
    {
        static bool isAlreadyCreated = false;
        static HttpClient client = new HttpClient();
        public LoginScreen()
        {
            InitializeComponent();
            if(!isAlreadyCreated)
            {
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                isAlreadyCreated = true;
            }
        }

        static async Task<HttpResponseMessage> LoginAsync(UserAuth user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "auth/login", user);

            return response;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // check email and password empty
            if (EmailTextBox.Text == "" || Password.Password == "")
            {
                MessageBox.Show("Credentials empty. Fill all the boxes first!");
                return;
            }
            //var response = await 
            try
            {
                UserAuth userAuth = new UserAuth
                {
                    Email = EmailTextBox.Text,
                    Password = Password.Password
                };
                UserAuthResponse userAuthResponse = null;
                var response = await LoginAsync(userAuth);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    userAuthResponse = await response.Content.ReadAsAsync<UserAuthResponse>();
                    if (KeepMeLoggedIn.IsChecked == true)
                    {
                        // store the JWT.
                        string destPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jwt");
                        File.WriteAllText(destPath, userAuthResponse.Token);
                    }
                    DashboardScreen dashboardScreen = new DashboardScreen(userAuthResponse);
                    dashboardScreen.Show();

                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    mainWindow.Close();


                }
                else
                {
                    //JsonSerializer serializer = new JsonSerializer();
                    string message = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GoToRegisterLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Main.Navigate(new RegisterScreen());
        }

        private void GoToForgotPasswordLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Main.Navigate(new ForgotPasswordScreen());
        }
    }
}