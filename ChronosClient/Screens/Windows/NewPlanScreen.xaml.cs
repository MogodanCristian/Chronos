using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;


namespace ChronosClient.Screens.Windows
{
    /// <summary>
    /// Interaction logic for NewPlanScreen.xaml
    /// </summary>
    public partial class NewPlanScreen : Window
    {
        public NewPlanScreen()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (inserted_name.Text.Length != 0)
            {
                //MessageBox.Show("Plan created succesfully!", "Information");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please complete the plan's name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
