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
    /// Interaction logic for GroupingHU.xaml
    /// </summary>
    public partial class GroupingHU : Page
    {
        public GroupingHU()
        {
            InitializeComponent();
            ImpBL bl = ImpBL.Instance;

        }

        private void GroupHUByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImpBL bl = ImpBL.Instance;

            try
            {
                if (groupByComboBox.SelectedIndex == 0)
                {
                    groupingDataGrid.Items.Clear();
                    groupingDataGrid.CanUserReorderColumns = false;
                    groupingDataGrid.CanUserResizeColumns = false;
                    groupingDataGrid.CanUserResizeRows = false;
                    groupingDataGrid.CanUserSortColumns = false;
                    var hu = bl.GroupHostingUnitsByArea();
                    foreach (var item in hu)
                    {
                        foreach (var hostingunit in item)
                        {
                            groupingDataGrid.Items.Add(hostingunit);
                        }
                    }
                }
                if (groupByComboBox.SelectedIndex == 1)
                {
                    groupingDataGrid.Items.Clear();
                    groupingDataGrid.CanUserReorderColumns = false;
                    groupingDataGrid.CanUserResizeColumns = false;
                    groupingDataGrid.CanUserResizeRows = false;
                    groupingDataGrid.CanUserSortColumns = false;
                    foreach (var item in bl.groupHostingUnitsByRates())
                    {
                        groupingDataGrid.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Backbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();

        }
    }
}