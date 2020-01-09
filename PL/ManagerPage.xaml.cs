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
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        ImpBL bl = ImpBL.Instance;
        NavigationService m_navigationService { get; set; }
        //public ManagerPage()
        //{
        //    InitializeComponent();
        //}
        public ManagerPage(NavigationService navigationService)
        {
            InitializeComponent();
            m_navigationService = navigationService;
        }


        private void AvailableUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AvailableU_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var ManagerPageAvailableUnit = new ManagerListsPage(amountTextBox.Text, dateTextBox.Text); //create your new form.
            this.NavigationService.Navigate(ManagerPageAvailableUnit);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GroupGRbyareas_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var ManagerPageAvailableUnit = new ManagerListsPage(); //create your new form.
            this.NavigationService.Navigate(ManagerPageAvailableUnit);
        }

        private void Hostlist_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var ManagerPageGetHostList = new ManagerListsPage(); //create your new form.
            this.NavigationService.Navigate(ManagerPageGetHostList);
        }

        private void OccupancyButtom_Click(object sender, RoutedEventArgs e)
        {

            float temp = bl.GetAnnualBusyPercentage(UnitTextBox.Text);
            answerUnitOccupancyTextBlock.Text= "The occupancy of this unit is: " + temp;
         }

            private void HostOccupancyButtom_Click(object sender, RoutedEventArgs e)
        {
            float temp = bl.GetAnnualBusyPercentageForAllUnitsForOneHost(HostOccupancyTextBox.Text);
            answerHostOccupancyTextBlock.Text = "The occupancy of this host is: " + temp;
        }

        private void AnswerUnitOccupancyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AllOccupancyButtom_Click(object sender, RoutedEventArgs e)
        {
            float temp = bl.GetAnnualBusyPercentageForAllUnitsForTheAdministor();
            answerAllOccupancyTextBlock.Text = "The overall occupancy is: " + temp;
            
        }
    }
}
