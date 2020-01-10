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
    /// Interaction logic for Grouping.xaml
    /// </summary>
    public partial class GroupingGR : Page
    {
        public GroupingGR()
        {
            InitializeComponent();
            ImpBL bl = ImpBL.Instance;
        }

        private void GroupByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImpBL bl = ImpBL.Instance;

            try
            {
                if(groupByComboBox.SelectedIndex==0)
                {
                    groupingDataGrid.CanUserSortColumns = false;
                    var gr = bl.GroupGuestRequestByAreas();
                    foreach (var item in gr)
                    {
                        foreach (var request in item)
                        {
                            groupingDataGrid.Items.Add(request);
                        }
                    }
                }
                if (groupByComboBox.SelectedIndex == 1)
                {
                    groupingDataGrid.CanUserSortColumns = false;
                    var gr = bl.GroupGuestRequestByNumOfAtendees();
                    foreach (var item in gr)
                    {
                        foreach (var request in item)
                        {
                            groupingDataGrid.Items.Add(request);
                        }
                        groupingDataGrid.Items.Add(new BE.GuestRequest());
                    }
                }
                if (groupByComboBox.SelectedIndex == 2)
                {
                    groupingDataGrid.CanUserSortColumns = false;
                    var gr = bl.GroupRequestByStatus();
                    foreach (var item in gr)
                    {
                        foreach (var request in item)
                        {
                            groupingDataGrid.Items.Add(request);
                        }
                        groupingDataGrid.Items.Add(new BE.GuestRequest());
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
