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
             DateTime d = DateTime.Parse(dateTextBox.Text);
                InitializeComponent();
                List<AvailableUnitItemControl> availableUnitItemControl = new List<AvailableUnitItemControl>();
                ImpBL bl = ImpBL.Instance;
                foreach (var item in bl.GetAllAvilableUnits(d, int.Parse(amountTextBox.Text)))
                {
                    AvailableUnitItemControl auic = new AvailableUnitItemControl();
                    auic.UnitNameTextBlock.Text = item.HostingUnitName;
                    availableUnitItemControl.Add(auic);
                }
                AvailableUnitListView.ItemsSource = availableUnitItemControl;

            try
            {
                if (dateTextBox.Text == "" || dateTextBox.Text == null)
                {
                    throw new TzimerException("Must enter an wanted dates!");
                }
                if (dateTextBox.Text != "dd/mm/yyyy" )
                {
                    throw new TzimerException("Not valid dates, try again.");
                }
                if (amountTextBox.Text == "" || amountTextBox.Text == null)
                {
                    throw new TzimerException("Must enter amount of wanted days!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            var groupGR = new GroupingGR(); //create your new form.
            this.NavigationService.Navigate(groupGR);
        }

        private void Hostlist_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var ManagerPageGetHostList = new ManagerListsPage(); //create your new form.
            this.NavigationService.Navigate(ManagerPageGetHostList);
        }

        private void OccupancyButtom_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            List<HostingUnit> mylist = bl.GetUnitsList();
            foreach (var item in mylist)
            {
                if (UnitTextBox.Text == item.HostingUnitName)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                float temp = bl.GetAnnualBusyPercentage(UnitTextBox.Text);
                answerUnitOccupancyTextBlock.Text = "The occupancy of this unit is: " + temp;
            }
            else
            {
                string titel = "Oops";
                string err = "Cannot find an HostingUnit with this name.";
                MessageBox.Show(err, titel);
            }
            
        }

        private void HostOccupancyButtom_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            List<Host> mylist = bl.GetHostsList();
            foreach (var item in mylist)
            {
                if (HostOccupancyTextBox.Text == item.HostId)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                float temp = bl.GetAnnualBusyPercentageForAllUnitsForOneHost(HostOccupancyTextBox.Text);
                answerHostOccupancyTextBlock.Text = "The occupancy of this host is: " + temp;
            }
            else
            {
                string titel = "Oops";
                string err = "Cannot find an Host with this ID.";
                MessageBox.Show(err, titel);
            }
            
        }

        private void AnswerUnitOccupancyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AllOccupancyButtom_Click(object sender, RoutedEventArgs e)
        {
            float temp = bl.GetAnnualBusyPercentageForAllUnitsForTheAdministor();
            answerAllOccupancyTextBlock.Text = "The overall occupancy is: " + temp;

        }

        private void NumberOfUnitsHostNameButton_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            List<Host> mylist = bl.GetHostsList();
            foreach (var item in mylist)
            {
                if (NumberOfUnitsHostNameTextBox.Text == item.HostId)
                {
                    flag = true;
                   
                }
            }
            if (flag)
            {
                int temp = bl.getNumOfUnits(NumberOfUnitsHostNameTextBox.Text);
                answerNumberOfUnitsTextBlock.Text = "The number of units this host has is: " + temp;
            }
            else
            {
                string titel = "Oops";
                string err = "Cannot find an Host with this ID.";
                MessageBox.Show(err, titel);
            }
        }

        private void GroupHU_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var groupHU = new GroupingHU(); //create your new form.
            this.NavigationService.Navigate(groupHU);
        }

        private void GroupH_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var groupH = new GroupingH(); //create your new form.
            this.NavigationService.Navigate(groupH);
        }

        private void NumberOfUnitsHostNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GetNumOfU_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AllNumberOfUnits_Click(object sender, RoutedEventArgs e)
        {
            int temp = bl.getOverallNumOfUnints();
            answerAllOccupancyTextBlock_Copy.Text = "The overall number of units is: " + temp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var groupO = new GroupingO(); //create your new form.
            this.NavigationService.Navigate(groupO);
        }

        private void AvailableUnitListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UnitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            List<GetBanksListItemControl> banksListItemControl = new List<GetBanksListItemControl>();
            ImpBL bl = ImpBL.Instance;
            foreach (var item in bl.GetBankList())
            {
                GetBanksListItemControl blic = new GetBanksListItemControl();
                blic.BankNameTextBlock.Text = item.BankName;
                banksListItemControl.Add(blic);
            }
            AvailableUnitListView.ItemsSource = banksListItemControl;
        }
    }
}
