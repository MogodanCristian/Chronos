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
    /// Interaction logic for MembersView.xaml
    /// </summary>
    public partial class MembersView : UserControl
    {
        public MembersView()
        {
            InitializeComponent();
        }

        public void addMemberItem(int userId, string firstName, string lastName, string email)
        {

            MembersWrapPanelPlanItems.Children.Add(new MemberItemComponent
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                Margin = new Thickness(10),
                Email = email
            });

        }

        public void clearMemeberItems()
        {
            if (MembersWrapPanelPlanItems.Children.Count > 0)
            {
                MembersWrapPanelPlanItems.Children.Clear();
            }
        }
    }
}