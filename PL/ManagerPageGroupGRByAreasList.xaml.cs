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
    /// Interaction logic for ManagerPageGroupGRByAreasList.xaml
    /// </summary>
    public partial class ManagerPageGroupGRByAreasList : Page
    {
        NavigationService navigationService { get; set; }
        public ManagerPageGroupGRByAreasList()
        {
            InitializeComponent();
        }
        public ManagerPageGroupGRByAreasList(NavigationService navigationService)
        {
            InitializeComponent();

            List<ManagerPageGroupGRByAreasItemControl> managerPageGroupGRByAreasItemControl = new List<ManagerPageGroupGRByAreasItemControl>();
            ImpBL bl = ImpBL.Instance;
            foreach (var item in bl.GroupGuestRequestByAreas())
            {

                AvailableUnitItemControl graic = new AvailableUnitItemControl();
                graic.UnitNameTextBlock.Text = item.;
                managerPageGroupGRByAreasItemControl.Add(graic);
            }
            ManagerPageGroupGRByAreasItemControl.ItemsSource = managerPageGroupGRByAreasItemControl;


        }
    }
}
}
