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
    /// Interaction logic for MemberItemComponent.xaml
    /// </summary>
    public partial class MemberItemComponent : UserControl
    {
        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register("FirstName", typeof(string), typeof(MemberItemComponent), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register("LastName", typeof(string), typeof(MemberItemComponent), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty UserIdProperty =
                 DependencyProperty.Register("UserId", typeof(int), typeof(MemberItemComponent), new PropertyMetadata(0));

        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register("Email", typeof(string), typeof(MemberItemComponent), new PropertyMetadata(string.Empty));

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public int UserId
        {
            get { return (int)GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }

        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }
        public MemberItemComponent()
        {
            InitializeComponent();
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;
            //PlanTitle.Text.StartsWith("C", true, CultureInfo.InvariantCulture
            if (img != null)
            {
                if (FirstName.StartsWith("A", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/a.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("B", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/b.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("C", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/c.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("D", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/d.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("E", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/e.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("F", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/f.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("G", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/g.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("H", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/h.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("I", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/i.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("J", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/j.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("K", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/k.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("L", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/l.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("M", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/m.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("N", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/n.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("O", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/o.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("P", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/p.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("Q", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/q.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("R", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/r.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("S", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/s.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("T", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/t.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("U", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/u.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("V", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/v.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("W", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/w.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("X", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/x.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("Y", true, CultureInfo.InvariantCulture))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"/Resources/Letters/y.png", UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    img.Source = bitmapImage;
                }
                else if (FirstName.StartsWith("Z", true, CultureInfo.InvariantCulture))
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