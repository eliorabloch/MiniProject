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
    /// Interaction logic for HostingUnitItemControl.xaml
    /// </summary>
    public partial class HostingUnitItemControl : UserControl
    {
        NavigationService m_navigationService { get; set; }
        HostingUnit m_hostingUnit;
        public HostingUnitItemControl(HostingUnit owner, NavigationService navigationService)
        {
            m_hostingUnit = owner;
            InitializeComponent();
            m_navigationService = navigationService;
        }

        private void EditHostinUnitBtn_Click(object sender, RoutedEventArgs e)//this takes us to edit the unit
        {
            try
            {
                int hostingUnitKey = int.Parse(HostingUnitKeyLable.Content.ToString().Substring(1));
                HostingUnitPage huw = new HostingUnitPage(m_hostingUnit.Owner, true, hostingUnitKey);
                m_navigationService.Navigate(huw);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);// throws a message if cant edit unit.
            }
        }

        private void DeleteHostingUnitBtn_Click(object sender, RoutedEventArgs e)//this takes us to delete the unit
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

        private void OrderHostingUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.m_navigationService.Navigate(new OrderListPage(m_hostingUnit));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
