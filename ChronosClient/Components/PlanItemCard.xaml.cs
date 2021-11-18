using ChronosClient.Screens.Pages;
using ChronosClient.Screens.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public static readonly DependencyProperty PlanIdProperty =
                  DependencyProperty.Register("PlanId", typeof(int), typeof(PlanItemCard), new PropertyMetadata(0));

        public static readonly DependencyProperty PlanTitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PlanItemCard), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PlanCreatedAtProperty =
            DependencyProperty.Register("CreatedAt", typeof(string), typeof(PlanItemCard), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PlanTokenProperty =
          DependencyProperty.Register("Token", typeof(string), typeof(PlanItemCard), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty UserIdProperty =
                 DependencyProperty.Register("UserId", typeof(int), typeof(PlanItemCard), new PropertyMetadata(0));
        public int PlanId
        {
            get { return (int)GetValue(PlanIdProperty); }
            set { SetValue(PlanIdProperty, value); }
        }

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

        public string Token
        {
            get { return (string)GetValue(PlanTokenProperty); }
            set { SetValue(PlanTokenProperty, value); }
        }

        public int UserId
        {
            get { return (int)GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }

       

        public PlanItemCard()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dashboardScreen = (DashboardScreen)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            dashboardScreen.dashboardFrame.Navigate(new PlanScreen(UserId,Token, PlanId));
        }

        void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;
            //PlanTitle.Text.StartsWith("C", true, CultureInfo.InvariantCulture
            if (img != null)
            {
                if (Title.StartsWith("A", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/a.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("B", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/b.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("C", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/c.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("D", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/d.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("E", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/e.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("F", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/f.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("G", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/g.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("H", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/h.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("I", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/i.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("J", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/j.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("K", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/k.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("L", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/l.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("M", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/m.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("N", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/n.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("O", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/o.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("P", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/p.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("Q", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/q.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("R", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/r.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("S", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/s.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("T", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/t.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("U", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/u.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("V", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/v.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("W", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/w.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("X", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/x.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("Y", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/y.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (Title.StartsWith("Z", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/z.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
            }
        }
    }
}