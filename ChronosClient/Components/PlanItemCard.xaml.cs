using ChronosClient.Screens.Pages;
using ChronosClient.Screens.Windows;
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

namespace ChronosClient.Components
{
    /// <summary>
    /// Interaction logic for PlanItemCard.xaml
    /// </summary>
    public partial class PlanItemCard : UserControl
    {
        public static readonly DependencyProperty PlanTitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PlanItemCard), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PlanCreatedAtProperty =
            DependencyProperty.Register("CreatedAt", typeof(string), typeof(PlanItemCard), new PropertyMetadata(string.Empty));

        public string Title
        {
            get { return (string)GetValue(PlanTitleProperty); }
            set { SetValue(PlanTitleProperty, value); }
        }

        public string CreatedAt
        {
            get { return (string)GetValue(PlanCreatedAtProperty); }
            set { SetValue(PlanCreatedAtProperty, value); }
        }

        public PlanItemCard()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dashboardScreen = Application.Current.MainWindow as DashboardScreen;
            dashboardScreen.dashboardFrame.Navigate(new PlanScreen());
        }
    }
}
