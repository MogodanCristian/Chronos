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
    /// Interaction logic for ResetPasswordScreen.xaml
    /// </summary>
    public partial class ResetPasswordScreen : Page
    {
        public ResetPasswordScreen()
        {
            InitializeComponent();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Main.Navigate(new ForgotPasswordScreen());
        }
    }
}