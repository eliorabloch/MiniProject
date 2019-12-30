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
    /// Interaction logic for OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        public OrderListPage(HostingUnit hostingUnit)
        {
            InitializeComponent();
            ImpBL bl = ImpBL.Instance;
            List<Order> orders = bl.GetOrdersByUnit(hostingUnit.HostingUnitKey);
            List<MyOrderItemControl> itemsToView = new List<MyOrderItemControl>();
            foreach (var order in orders)
            {
                itemsToView.Add(new MyOrderItemControl(order));
            }
            MyOrderListView.ItemsSource = itemsToView;
        }
    }
}
