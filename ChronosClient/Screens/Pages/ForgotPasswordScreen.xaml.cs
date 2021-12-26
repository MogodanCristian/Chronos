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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChronosClient.Models;
using ChronosClient.Screens.Windows;

namespace ChronosClient.Screens.Pages
{
    /// <summary>
    /// Interaction logic for ForgotPasswordScreen.xaml
    /// </summary>
    public partial class ForgotPasswordScreen : Page
    {
        static bool isAlreadyInstantiated = false;
        static int val_code = 0;
        static HttpClient client = new HttpClient();
        public ForgotPasswordScreen()
        {
            if (!isAlreadyInstantiated)
            {
                client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                isAlreadyInstantiated = true;
            }
            InitializeComponent();
        }

        private async Task<HttpResponseMessage> SendEmailForgotPasswordAsync(EmailModel emailModel)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("email", emailModel);
            return response;
        }

        private bool isOnlyDigitsString(string txt)
        {
            foreach(char x in txt)
            {
                if(x < '0' || x > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private void reset_code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if(isOnlyDigitsString(reset_code_textbox.Text) && Convert.ToInt32(reset_code_textbox.Text) == val_code)
                {
                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    mainWindow.Main.Navigate(new ResetPasswordScreen(reset_email.Text));
                }
                else
                {
                    MessageBox.Show("Invalid Validation Code! Who are you really?");
                    return;
                }
            }
        }

        private async void reset_button_Click(object sender, RoutedEventArgs e)
        {
            if (reset_email.Text.Length == 0)
            {
                MessageBox.Show("You should complete this field if you want your password recovered in this lifetime.");
            }
            else
            {
                Random generator = new Random();
                val_code = generator.Next(100000, 1000000);
                string msg = $"Dear Chronos user,\nHere is your validation code: {val_code}.\n\nThis notification is sent by Chronos Dev Team.";

                EmailModel emailModel = new EmailModel
                {
                    toname = "First Name Last Name",
                    toemail = reset_email.Text,
                    subject = "Chronos Password Reset",
                    message = msg
                };

                var response = await SendEmailForgotPasswordAsync(emailModel);
                if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Invalid email address! Do not mess with us!");
                    reset_email.Text = "";
                    return;
                }

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    reset_code_label.Visibility = Visibility.Visible;
                    reset_code_textbox.Visibility = Visibility.Visible;
                    reset_button.IsEnabled = false;
                }
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Main.Navigate(new LoginScreen());
        }
    }
}