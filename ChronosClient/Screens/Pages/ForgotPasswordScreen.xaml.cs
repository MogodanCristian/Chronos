using System;
using System.Collections.Generic;
using System.Linq;
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
using ChronosClient.Screens.Windows;

namespace ChronosClient.Screens.Pages
{
    /// <summary>
    /// Interaction logic for ForgotPasswordScreen.xaml
    /// </summary>
    public partial class ForgotPasswordScreen : Page
    {
        public ForgotPasswordScreen()
        {
            InitializeComponent();
        }

        private void reset_code_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key== System.Windows.Input.Key.Enter && reset_code_textbox.Text=="666")
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.Main.Navigate(new ResetPasswordScreen());
            }
        }

        private void reset_button_Click(object sender, RoutedEventArgs e)
        {
            if(reset_email.Text.Length==0)
            {
                MessageBox.Show("You should complete this field if you want your password recovered in this lifetime.");
            }
            else
            {
                reset_code_label.Visibility = Visibility.Visible;
                reset_code_textbox.Visibility = Visibility.Visible;
                //trimite mail cu kombynatzy

            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Main.Navigate(new LoginScreen());
        }
    }
}
