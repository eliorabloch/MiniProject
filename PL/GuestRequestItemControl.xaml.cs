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

namespace PL
{
    /// <summary>
    /// Interaction logic for GuestRequestItemControl.xaml
    /// </summary>
    public partial class GuestRequestItemControl : UserControl
    {
        public GuestRequestItemControl()
        {
            InitializeComponent();
        }

        private void DeleteHostingUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImpBL bl = ImpBL.Instance;
                int GuestRequestKey = int.Parse(GuestRequestKeyLable.Content.ToString().Substring(1));
                bl.DeleteRequest(bl.GetRequest(GuestRequestKey));
                UserControlContainer.Visibility = Visibility.Collapsed;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void RequestInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            ImpBL bl = ImpBL.Instance;
            int GuestRequestKey = int.Parse(GuestRequestKeyLable.Content.ToString().Substring(1));
            GuestRequestWindow obj = new GuestRequestWindow(true,GuestRequestKey);
            this.Visibility = Visibility.Hidden;
            obj.Show();
        }
    }
}
