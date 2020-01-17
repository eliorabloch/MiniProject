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
    /// Interaction logic for MyOrderItemControl.xaml
    /// </summary>
    public partial class MyOrderItemControl : UserControl
    {
        Order m_order;
        public MyOrderItemControl(Order order)
        {
            InitializeComponent();
            m_order = order;
            OrderIdLable.Content = order.OrderKey;
            OrderStatusComboBox.ItemsSource = Enum.GetNames(typeof(OrderStatus)).ToList();
            OrderStatusComboBox.SelectedValue = order.Status.ToString();
            
        }

        private void SaveStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_order.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), OrderStatusComboBox.SelectedValue.ToString(), true); 
                ImpBL bl = ImpBL.Instance;
                bl.UpdateOrder(m_order);
                Utils.navigationService.GoBack();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
