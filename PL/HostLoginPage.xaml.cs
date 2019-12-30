using BE;
using BL;
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
    /// Interaction logic for HostLoginPage.xaml
    /// </summary>
    public partial class HostLoginPage : Page
    {
        public HostLoginPage()
        {
            InitializeComponent();
        }

        private void LoginHostBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hostId = HostIdTextBox.Text;
                var bl = ImpBL.Instance;
                Host host = bl.GetHost(hostId);
                this.NavigationService.Navigate(new HostinUnitListPage(host, this.NavigationService));

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateNewHostBtn_Click(object sender, RoutedEventArgs e)
        {
            var hip =  new HostInformationPage();
            this.NavigationService.Navigate(hip);

        }
    }
}
