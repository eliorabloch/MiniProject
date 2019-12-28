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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for HostinUnitListWindow.xaml
    /// </summary>
    public partial class HostinUnitListWindow : Window
    {
        public HostinUnitListWindow()
        {
            InitializeComponent();
            List<HostingUnitItemControl> hostingUnitsItemsControl = new List<HostingUnitItemControl>();
            ImpBL bl = ImpBL.Instance;
            foreach (var item in bl.GetUnitsList())
            {
                HostingUnitItemControl huic = new HostingUnitItemControl();
                huic.HostinUnitNameTextBlock.Text = item.HostingUnitName;
                huic.HostingUnitKeyLable.Content = "#" + item.HostingUnitKey;
                hostingUnitsItemsControl.Add(huic);
            }
            HostingUnitListView.ItemsSource = hostingUnitsItemsControl;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
