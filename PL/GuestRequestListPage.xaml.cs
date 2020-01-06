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
    /// Interaction logic for GuestRequestListWindow.xaml
    /// </summary>
    public partial class GuestRequestListPage : Page

    {
      

       

        NavigationService m_navigationService { get; set; }

        public GuestRequestListPage(NavigationService navigationService)
        {
            InitializeComponent();
            m_navigationService = navigationService;
            List<GuestRequestItemControl> guestRequestItemsControl = new List<GuestRequestItemControl>();
             ImpBL bl = ImpBL.Instance;
            foreach (var item in bl.GetGuestRequestList())
            {
                GuestRequestItemControl gric = new GuestRequestItemControl( navigationService);
                gric.GuestRequestTextBlock.Text = item.PrivateName+ " " + item.FamilyName;
                gric.GuestRequestKeyLable.Content = "#" + item.GuestRequestKey;
                guestRequestItemsControl.Add(gric);
            }
            HostingUnitListView.ItemsSource = guestRequestItemsControl;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {


            var GuestRequestPage = new GuestRequestPage(); //create your new form.
            this.NavigationService.Navigate(GuestRequestPage);
        }

        private void HostingUnitListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void fullNameSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
    
        }

        private void searchByNameBtn_Click(object sender, RoutedEventArgs e)
        {

            ImpBL bl = ImpBL.Instance;

            List<GuestRequestItemControl> SubguestRequestItemsControl = new List<GuestRequestItemControl>();
            try
            {
                foreach (var item in bl.searchByName(bl.GetGuestRequestList(), fullNameSearchTextBox.Text))
                {
                    GuestRequestItemControl sgric = new GuestRequestItemControl(m_navigationService);
                    sgric.GuestRequestTextBlock.Text = item.PrivateName + " " + item.FamilyName;
                    sgric.GuestRequestKeyLable.Content = "#" + item.GuestRequestKey;
                    SubguestRequestItemsControl.Add(sgric);
                }

                HostingUnitListView.ItemsSource = SubguestRequestItemsControl;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void searchByKeyBtn_Click(object sender, RoutedEventArgs e)
        {

            ImpBL bl = ImpBL.Instance;

            List<GuestRequestItemControl> SubguestRequestItemsControl = new List<GuestRequestItemControl>();
            try
            {
                int Key = int.Parse(searchByKeyTextBox.Text);
                GuestRequest gr = bl.searchByKey(bl.GetGuestRequestList(), Key);


                GuestRequestItemControl sgric = new GuestRequestItemControl(m_navigationService);
                sgric.GuestRequestTextBlock.Text = gr.PrivateName + " " + gr.FamilyName;
                sgric.GuestRequestKeyLable.Content = "#" + gr.GuestRequestKey;
                SubguestRequestItemsControl.Add(sgric);
            

                HostingUnitListView.ItemsSource = SubguestRequestItemsControl;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void searchByKeyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
