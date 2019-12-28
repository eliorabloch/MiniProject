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
    /// Interaction logic for HostingUnitItemControl.xaml
    /// </summary>
    public partial class HostingUnitItemControl : UserControl
    {
        public HostingUnitItemControl()
        {
            InitializeComponent();
        }

        private void EditHostinUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int hostingUnitKey = int.Parse(HostingUnitKeyLable.Content.ToString().Substring(1));
                HostingUnitWindow huw = new HostingUnitWindow(true, hostingUnitKey);
                huw.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteHostingUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImpBL bl = ImpBL.Instance;
                int unitKey = int.Parse(HostingUnitKeyLable.Content.ToString().Substring(1));
                bl.DeleteUnit(bl.GetUnit(unitKey));
                UserControlContainer.Visibility = Visibility.Collapsed;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
