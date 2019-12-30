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

namespace PL
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void GeustRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            GuestRequestListWindow obj = new GuestRequestListWindow();
            this.Visibility = Visibility.Hidden;
            obj.Show();
        }

        private void HostingUnitBTN_Click(object sender, RoutedEventArgs e)
        {
            var HostLoginPage = new HostLoginPage(); //create your new form.
            this.NavigationService.Navigate(HostLoginPage);
            //this.Content = HostLoginPage;
        }

        private void MannagerBtn_Click(object sender, RoutedEventArgs e)
        {
            ManagerPage obj = new ManagerPage();
            this.Visibility = Visibility.Hidden;
            //obj.Show();

        }
    }
}
