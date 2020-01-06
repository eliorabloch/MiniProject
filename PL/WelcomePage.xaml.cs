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
        NavigationService m_navigationService { get; set; }
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void GeustRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var GuestRequestPage = new GuestRequestListPage(m_navigationService); //create your new form.
            this.NavigationService.Navigate(GuestRequestPage);
          
        }

        private void HostingUnitBTN_Click(object sender, RoutedEventArgs e)
        {
            var HostLoginPage = new HostLoginPage(); //create your new form.
            this.NavigationService.Navigate(HostLoginPage);
        }

        private void MannagerBtn_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var ManagerPage = new ManagerPage(m_navigationService); //create your new form.
            this.NavigationService.Navigate(ManagerPage);

        }
    }
}
