using ChronosClient.Screens;
using ChronosClient.Screens.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ChronosClient.Screens.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!checkIfUserLoggedIn())
            {
                Main.Content = new LoginScreen();
            }
        }

        private bool checkIfUserLoggedIn()
        {
            string destPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jwt");
            if(!File.Exists(destPath)) {
                return false;
            }
            string jwt = System.IO.File.ReadAllText(destPath);
            if (jwt != "")
            {
                DashboardScreen dashboardScreen = new DashboardScreen(jwt);
                dashboardScreen.Show();

                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.Close();
                return true;
            }
            return false;
        }
    }
}
