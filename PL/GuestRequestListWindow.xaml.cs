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
using System.Windows.Shapes;
using BL;

namespace PL
{
    /// <summary>
    /// Interaction logic for GuestRequestListWindow.xaml
    /// </summary>
    public partial class GuestRequestListWindow : Window
    {
        public GuestRequestListWindow()
        {
            InitializeComponent();
            List<GuestRequestItemControl> guestRequestItemsControl = new List<GuestRequestItemControl>();
             ImpBL bl = ImpBL.Instance;
            foreach (var item in bl.GetGuestRequestList())
            {
                GuestRequestItemControl gric = new GuestRequestItemControl() ;
                gric.GuestRequestTextBlock.Text = item.PrivateName+ " " + item.FamilyName;
                gric.GuestRequestKeyLable.Content = "#" + item.GuestRequestKey;
                guestRequestItemsControl.Add(gric);
            }
            HostingUnitListView.ItemsSource = guestRequestItemsControl;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

           GuestRequestWindow obj = new GuestRequestWindow();
            this.Visibility = Visibility.Hidden;
            obj.Show();
        }

        private void HostingUnitListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Visibility = Visibility.Hidden;
            obj.Show();
        }
    }
}
