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
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for GuestRequestInfoPage.xaml
    /// </summary>
    public partial class GuestRequestInfoPage : Page
    { int Gkey { get; set; }
        public GuestRequestInfoPage(int key)
        {
            Gkey = key;
            InitializeComponent();
            ImpBL bl = ImpBL.Instance;
            infoTextBlock.Text = bl.GetRequest(Gkey).ToString();


        }

       

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void HomeBTN_Click(object sender, RoutedEventArgs e)
        {
            var HOMEPAGE = new WelcomePage();
            this.NavigationService.Navigate(HOMEPAGE);

        }
    }
}
