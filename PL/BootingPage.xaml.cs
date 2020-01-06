using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using BL;
using BE;


namespace PL
{
    /// <summary>
    /// Interaction logic for BootingPage.xaml
    /// </summary>

    public partial class BootingPage : Page
    {
        public BootingPage()
        {
            InitializeComponent();
        }
        DispatcherTimer timer = new DispatcherTimer();

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += changePage;
            timer.Start();
        }

        private void changePage(object sender, EventArgs e)
        {
            timer.Stop();
            Utils.navigationService = this.NavigationService;
            this.NavigationService.Navigate(new WelcomePage());
        }
    }


}

