using ChronosClient.Models;
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

namespace ChronosClient.Screens
{
    /// <summary>
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        static HttpClient client = new HttpClient();

        public RegisterScreen()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://chronosapi.azurewebsites.net/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static async Task<HttpResponseMessage> RegisterAsync(User user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("auth/register", user);

            return response;
        }

        private async void register_button_Click(object sender, RoutedEventArgs e)
        {

            // VALIDATE CREDENTIALS EMPTY
            if (first_name.Text.Length == 0)
            {
                MessageBox.Show("Please complete the First Name field!", "Warning");
                return;
            }
            if (last_name.Text.Length == 0)
            {
                MessageBox.Show("Please complete the Last Name field!", "Warning");
                return;
            }
            if (email.Text.Length == 0)
            {
                MessageBox.Show("Please complete the Email field!", "Warning");
                return;
            }
            if (password.Password.Length == 0)
            {
                MessageBox.Show("Please complete the password field!", "Warning");
                return;
            }
            if (confirm_password.Password.Length == 0)
            {
                MessageBox.Show("Please complete the confirm passowrd field!", "Warning");
                return;
            }
            if (!date.SelectedDate.HasValue)
            {
                MessageBox.Show("Please complete the date of birth field!", "Warning");
                return;
            }

            try
            {
                User user = new User
                {
                    FirstName = first_name.Text,
                    LastName = last_name.Text,
                    Password = password.Password,
                    Email = email.Text,
                    DateOfBirth = date.SelectedDate
                };

                var response = await RegisterAsync(user);
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("User created successfully!");
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            bool isValidPassword = password.Password.Any(char.IsDigit) && password.Password.Any(char.IsLetter) && password.Password.Any(char.IsSymbol);
            if (password.Password.Length >= 6 && isValidPassword)
            {
                password_ok.Content = "Password is valid!";
            } else
            {
                password_ok.Content = "Password isn't yet valid!";
            }
        }

        private void confirm_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (confirm_password.Password == password.Password)
            {
                password_match.Content = "Passwords match!";       
            } else
            {
                password_match.Content = "Passwords don't match!";
                password_match.Visibility = Visibility.Visible;
            }
        }
    }
}