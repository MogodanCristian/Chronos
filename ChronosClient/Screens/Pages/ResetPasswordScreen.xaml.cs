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
using ChronosClient.Screens.Windows;

namespace ChronosClient.Screens.Pages
{
    /// <summary>
    /// Interaction logic for ResetPasswordScreen.xaml
    /// </summary>
    public partial class ResetPasswordScreen : Page
    {
        static bool isAlreadyInstantiated = false;
        static HttpClient client = new HttpClient();
        string _email;
        public ResetPasswordScreen(string email)
        {
            if (!isAlreadyInstantiated)
            {
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                isAlreadyInstantiated = true;
            }
            InitializeComponent();
            _email = email;
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Main.Navigate(new ForgotPasswordScreen());
        }
        private async Task<HttpResponseMessage> ChangePasswordAsync(ResetPasswordModel resetPasswordModel)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("users/reset-password", resetPasswordModel);
            return response;
        }

        private async void change_password_button_Click(object sender, RoutedEventArgs e)
        {
            if(password.Password != confirm_password.Password)
            {
                MessageBox.Show("Passwords do not match!!!");
                return;
            }
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                email = _email,
                newPassword = confirm_password.Password
            };

            var response = await ChangePasswordAsync(resetPasswordModel);
            if(response.StatusCode == HttpStatusCode.BadRequest)
            {
                MessageBox.Show(response.Content.ToString());
                return;
            }

            MessageBox.Show("We updated your password successfully!!");
        }
    }
}