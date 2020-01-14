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
           
        }
        public ManagerListsPage(string amountofdays, string date)
        {
           
        }

        private void AvailableUnitListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Backbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}