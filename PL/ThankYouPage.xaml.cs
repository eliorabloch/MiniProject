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
using BL;
using System.Windows.Threading;
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for ThankYouPage.xaml
    /// </summary>
    public partial class ThankYouPage : Page
    {
        public ThankYouPage()
        {
            InitializeComponent();
        }
        DispatcherTimer timer = new DispatcherTimer();

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(4);
            timer.Tick += changePage;
            timer.Start();
        }

        private void changePage(object sender, EventArgs e)
        {
            timer.Stop();
            Utils.navigationService = this.NavigationService;
            this.NavigationService.Navigate(new GuestRequestListPage(Utils.navigationService));
        }
    }
}
