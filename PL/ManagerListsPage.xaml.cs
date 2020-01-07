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
    /// Interaction logic for ManagerPageAvailableUnitList.xaml
    /// </summary>
    public partial class ManagerListsPage : Page
    {
        NavigationService m_navigationService { get; set; }

        public ManagerListsPage()
        {
            InitializeComponent();
            List<GetHostListItemControl> getHostListsPage = new List<GetHostListItemControl>();
            ImpBL bl = ImpBL.Instance;
            
            foreach (var item in bl.GetUnitsList())
            {
                    GetHostListItemControl ghlic = new GetHostListItemControl();
                    ghlic.HostNameTextBlock.Text = item.Owner.PrivateName + " " + item.Owner.FamilyName;
                    ghlic.HostKeyLable.Content = "#" + item.Owner.HostId;
                    getHostListsPage.Add(ghlic);
            }
            AvailableUnitListView.ItemsSource = getHostListsPage;
        }
        public ManagerListsPage(string amountofdays, string date)
        {
            DateTime d = DateTime.Parse(date);
            InitializeComponent();
            List<AvailableUnitItemControl> availableUnitItemControl = new List<AvailableUnitItemControl>();
            ImpBL bl = ImpBL.Instance;
            foreach (var item in bl.GetAllAvilableUnits(d, int.Parse(amountofdays)))
            {
                AvailableUnitItemControl auic = new AvailableUnitItemControl();
                auic.UnitNameTextBlock.Text = item.HostingUnitName;
                availableUnitItemControl.Add(auic);
            }
            AvailableUnitListView.ItemsSource = availableUnitItemControl;
           
        }

        private void AvailableUnitListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}