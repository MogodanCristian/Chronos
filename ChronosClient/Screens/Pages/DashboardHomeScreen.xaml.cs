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

namespace ChronosClient.Screens.Pages
{
    /// <summary>
    /// Interaction logic for DashboardHomeScreen.xaml
    /// </summary>
    public partial class DashboardHomeScreen : Page
    {
        public DashboardHomeScreen()
        {
            InitializeComponent();
            PlanItemsWrapPanel.addPlanItem("Combinatii", "11-16-2021");
            PlanItemsWrapPanel.addPlanItem("Combinatii", "11-16-2021");
            PlanItemsWrapPanel.addPlanItem("Combinatii", "11-16-2021");
            PlanItemsWrapPanel.addPlanItem("Combinatii", "11-16-2021");
        }
    }
}
