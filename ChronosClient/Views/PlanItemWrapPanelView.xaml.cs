using ChronosClient.Components;
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

namespace ChronosClient.Views
{
    /// <summary>
    /// Interaction logic for PlanItemStackPanelView.xaml
    /// </summary>
    public partial class PlanItemWrapPanelView : UserControl
    {
        public PlanItemWrapPanelView()
        {
            InitializeComponent();
        }

        public void addPlanItem(int id, string title, string createdAt, string token, int userId)
        {
            WrapPanelPlanItems.Children.Add(new PlanItemCard(token)
            {
                PlanId = id,
                Title = title,
                UserId = userId,
                CreatedAt = createdAt,
                Token = token,
                Margin = new Thickness(10)
            });
        }

        public void clearPlanItems()
        {
            if(WrapPanelPlanItems.Children.Count > 0)
            {
                WrapPanelPlanItems.Children.Clear();
            }
        }

    }
}
