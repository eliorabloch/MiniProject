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
    /// Interaction logic for SuggetionOrderItemControl.xaml
    /// </summary>
    public partial class SuggetionOrderItemControl : UserControl
    {
        GuestRequest guestRequest;
        HostingUnit hostingUnit;
        OrderListPage orderListPage;
        public SuggetionOrderItemControl(GuestRequest gr, HostingUnit hu, OrderListPage olp)
        {
            try
            {
                InitializeComponent();
                guestRequest = gr;
                hostingUnit = hu;
                orderListPage = olp;
                GuestRequestPrivateNameLable.Content = guestRequest.PrivateName;
                GuestRequestFamilyNameLable.Content = guestRequest.FamilyName;
    
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GuestRequestDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    
                Utils.navigationService.Navigate(new GuestRequestInfoPage(guestRequest.GuestRequestKey));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GuestRequestInviteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var myBL = ImpBL.Instance;

                var order = new Order
                {
                    CreateDate = DateTime.Now,
                    GuestRequestKey = guestRequest.GuestRequestKey,
                    OrderKey = Configuration.OrderId++,
                    Status = OrderStatus.NotHandled,
                    OrderDate = DateTime.Now,
                    HostingUnitKey = hostingUnit.HostingUnitKey
                };
                myBL.AddOrder(order);
                // Task.Run(() =>
                myBL.SendOrder(hostingUnit.Owner, order,hostingUnit);
                //Utils.navigationService.GoBack();
                orderListPage.LoadLists();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
