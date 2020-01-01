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
using System.Windows.Navigation;
using BL;
using BE;


namespace PL
{
    /// <summary>
    /// Interaction logic for GuestRequestWindow.xaml
    /// </summary>
    public partial class GuestRequestPage : Page
    {
        public GuestRequestPage()
        {
            InitializeComponent();
        }



        public GuestRequestPage(bool isExistingReq, NavigationService navigationService,int key = -1)
        {
            InitializeComponent();
            ImpBL bl = ImpBL.Instance;
            GuestRequest gr = bl.GetRequest(key);

            gr.Status = RequestStatus.Open;

            statusLable.Content = gr.Status;
            GuestRequestKeyLable.Content = key;
            GuestRequestFirstNameTextBox.Text = gr.PrivateName;
            GuestRequestlastNameTextBox.Text = gr.FamilyName;
            PhoneNumbertTextBox.Text = gr.PhoneNumber;
            ChildrenTextBox.Text = gr.Children;
            AdultsTextBox.Text = gr.Adults;
            EmailTextBox.Text = gr.MailAddress;
            SubAreaTextBox.Text = gr.SubArea;
            // FromDateCalender.SelectedDates[0] = gr.EntryDate;
            // ToDateCalender.SelectedDates[0] = gr.ReleaseDate ;
            switch (gr.Area)
            {
                case Areas.South:
                    AreaComboBox.SelectedIndex = 3;
                    break;
                case Areas.North:
                    AreaComboBox.SelectedIndex = 2;
                    break;
                case Areas.Center:
                    AreaComboBox.SelectedIndex = 1;
                    break;
                case Areas.Jerusalem:
                    AreaComboBox.SelectedIndex = 0;
                    break;
                default:
                    break;
            }

            switch (gr.Type)
            {
                case UnitType.Tzimer:
                    TypeComboBox.SelectedIndex = 0;
                    break;
                case UnitType.HostingUnit:
                    TypeComboBox.SelectedIndex = 1;
                    break;
                case UnitType.HotelRoom:
                    TypeComboBox.SelectedIndex = 2;
                    break;
                case UnitType.Tent:
                    TypeComboBox.SelectedIndex = 3;
                    break;
                default:
                    break;
            }
            switch (gr.Pool)

            {
                case Options.possible:
                    PPossible.IsChecked = true;
                    break;
                case Options.neccesery:
                    PNeccesery.IsChecked = true;
                    break;
                case Options.notintersted:
                    PNotintersted.IsChecked = true;
                    break;
                default:
                    break;
            }
            switch (gr.Garden)

            {
                case Options.possible:
                    GPossible.IsChecked = true;
                    break;
                case Options.neccesery:
                    GNeccesery.IsChecked = true;
                    break;
                case Options.notintersted:
                    GNotintersted.IsChecked = true;
                    break;
                default:
                    break;
            }
            switch (gr.Jacuzz)

            {
                case Options.possible:
                    JPossible.IsChecked = true;
                    break;
                case Options.neccesery:
                    JNeccesery.IsChecked = true;
                    break;
                case Options.notintersted:
                    JNotintersted.IsChecked = true;
                    break;
                default:
                    break;
            }
            switch (gr.ChildrensAttractions)

            {
                case Options.possible:
                    CPossible.IsChecked = true;
                    break;
                case Options.neccesery:
                    CNeccesery.IsChecked = true;
                    break;
                case Options.notintersted:
                    CNotintersted.IsChecked = true;
                    break;
                default:
                    break;
            }
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                {
                    ImpBL bl = ImpBL.Instance;
                    GuestRequest gr = new GuestRequest();
                    gr.Status = RequestStatus.Open;

                    statusLable.Content = gr.Status;

                    gr.PrivateName = GuestRequestFirstNameTextBox.Text;
                    gr.FamilyName = GuestRequestlastNameTextBox.Text;
                    gr.PhoneNumber = PhoneNumbertTextBox.Text;
                    gr.Children = ChildrenTextBox.Text;
                    gr.Adults = AdultsTextBox.Text;
                    gr.MailAddress = EmailTextBox.Text;
                    gr.Area = (BE.Areas)AreaComboBox.SelectedIndex;
                    gr.Type = (BE.UnitType)AreaComboBox.SelectedIndex;
                    gr.SubArea = SubAreaTextBox.Text;
                    gr.EntryDate = FromDateCalender.SelectedDates[0];
                    gr.ReleaseDate = ToDateCalender.SelectedDates[0];

                    switch (AreaComboBox.SelectedIndex)
                    {
                        case 0:
                            gr.Area = Areas.Jerusalem;
                            break;
                        case 1:
                            gr.Area = Areas.Center;

                            break;
                        case 2:
                            gr.Area = Areas.North;
                            break;
                        case 3:
                            gr.Area = Areas.South;

                            break;
                        default:
                            break;
                    }
                    switch (TypeComboBox.SelectedIndex)
                    {
                        case 0:
                            gr.Type = UnitType.Tzimer;
                            break;
                        case 1:
                            gr.Type = UnitType.HostingUnit;

                            break;
                        case 2:
                            gr.Type = UnitType.HotelRoom;

                            break;
                        case 3:
                            gr.Type = UnitType.Tent;

                            break;
                        default:
                            break;
                    }
                    #region childrenattractions
                    switch (CNotintersted.IsChecked)
                    {
                        case true:
                            gr.ChildrensAttractions = Options.notintersted;
                            break;

                    }
                    switch (CPossible.IsChecked)
                    {
                        case true:
                            gr.ChildrensAttractions = Options.possible;
                            break;


                    }
                    switch (CNeccesery.IsChecked)
                    {
                        case true:
                            gr.ChildrensAttractions = Options.neccesery;
                            break;


                    }
                    #endregion
                    #region Pool
                    switch (PNotintersted.IsChecked)
                    {
                        case true:
                            gr.Pool = Options.notintersted;
                            break;

                    }
                    switch (PPossible.IsChecked)
                    {
                        case true:
                            gr.Pool = Options.possible;
                            break;


                    }
                    switch (PNeccesery.IsChecked)
                    {
                        case true:
                            gr.Pool = Options.neccesery;
                            break;


                    }
                    #endregion
                    #region Jacuzz
                    switch (JNotintersted.IsChecked)
                    {
                        case true:
                            gr.Jacuzz = Options.notintersted;
                            break;

                    }
                    switch (JPossible.IsChecked)
                    {
                        case true:
                            gr.Jacuzz = Options.possible;
                            break;


                    }
                    switch (JNeccesery.IsChecked)
                    {
                        case true:
                            gr.Jacuzz = Options.neccesery;
                            break;


                    }
                    #endregion
                    #region Garden
                    switch (GNotintersted.IsChecked)
                    {
                        case true:
                            gr.Garden = Options.notintersted;
                            break;

                    }
                    switch (GPossible.IsChecked)
                    {
                        case true:
                            gr.Garden = Options.possible;
                            break;


                    }
                    switch (GNeccesery.IsChecked)
                    {
                        case true:
                            gr.Garden = Options.neccesery;
                            break;


                    }
                    #endregion
                    bl.AddRequest(gr);
                   

                    var GlPAGE = new GuestRequestListPage();
                    this.NavigationService.Navigate(GlPAGE);

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

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}































