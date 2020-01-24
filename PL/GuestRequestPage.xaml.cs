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
            TypeComboBox.ItemsSource = Enum.GetNames(typeof(UnitType)).ToList();
            //    TypeComboBox.SelectedValue = gr.Type.ToString();

        }


        
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImpBL bl = ImpBL.Instance;
                GuestRequest gr = new GuestRequest();
                gr.Status = RequestStatus.Open;

                gr.RegistrationDate = DateTime.Now;
                gr.EntryDate = FromDateCalender.SelectedDates[0];
                gr.ReleaseDate = ToDateCalender.SelectedDates[0];


                if (FromDateCalender.SelectedDates.Count == 0)
                {
                    throw new TzimerException("Must choose entry date", "pl");
                }
                if (ToDateCalender.SelectedDates.Count == 0)
                {
                    throw new TzimerException("Must choose leave date", "pl");
                }
                if ((gr.ReleaseDate - gr.EntryDate).TotalDays < 1)
                {
                    throw new TzimerException("Sorry, the dates you chose are invalid, entry must be before leave!", "bl");
                }


                gr.PrivateName = GuestRequestFirstNameTextBox.Text;
                if (gr.PrivateName == null)

                {
                    throw new TzimerException("Must enter a Private Name");
                }
                gr.FamilyName = GuestRequestlastNameTextBox.Text;
                
                if (gr.FamilyName==null)
                {
                    throw new TzimerException("Must enter a Family name");
                }
                gr.PhoneNumber = PhoneNumbertTextBox.Text;
                if (gr.PhoneNumber == null)
                {
                    throw new TzimerException("Must enter a Phone number");
                }
                int number;
                bool checknumber = Int32.TryParse(gr.PhoneNumber, out number);
                if (!checknumber)
                {
                    throw new TzimerException("Phone number must contain only numbers.", "bl");

                }
              
               
                if (string.IsNullOrEmpty(gr.PhoneNumber))
                {
                    throw new TzimerException("Please enter your phone number", "bl");
                }
                gr.MailAddress = EmailTextBox.Text;

                if (!(gr.MailAddress.Contains("@")))
                {
                    throw new TzimerException("E-mail Address format is invaled.Please enter the correct format.", "bl");
                }
                if (string.IsNullOrEmpty(gr.MailAddress))
                {
                    throw new TzimerException("Please enter your e-mail address", "bl");
                }
               
               
               
                gr.Adults = AdultsTextBox.Text;
                if (string.IsNullOrEmpty(gr.Adults))
                {
                    throw new TzimerException("Must enter the amount of adults", "bl");

                }

                if (gr.Adults == "0")
                {
                    throw new TzimerException("Cannot set request with zero adults!", "bl");
                }
                gr.Children = ChildrenTextBox.Text;
                if (string.IsNullOrEmpty(gr.Children))
                {
                    throw new TzimerException("Please enter the amount of children", "bl");

                }


                gr.Area = (BE.Areas)AreaComboBox.SelectedIndex;
                gr.Type = (BE.UnitType)AreaComboBox.SelectedIndex;
                gr.SubArea = SubAreaTextBox.Text;
               
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

                gr.Type = (UnitType)Enum.Parse(typeof(UnitType), TypeComboBox.SelectedValue.ToString(), true);

                #region breakfastIncluded
                switch (BNotintersted.IsChecked)
                {
                    case true:
                        gr.breakfastIncluded = Options.notintersted;
                        break;

                }
                switch (BPossible.IsChecked)
                {
                    case true:
                        gr.breakfastIncluded = Options.possible;
                        break;


                }
                switch (BNeccesery.IsChecked)
                {
                    case true:
                        gr.breakfastIncluded = Options.neccesery;
                        break;


                }
                #endregion
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
                #region Air conditioner
                switch (ANotintersted.IsChecked)
                {
                    case true:
                        gr.AirConditoiner = Options.notintersted;
                        break;

                }
                switch (APossible.IsChecked)
                {
                    case true:
                        gr.AirConditoiner = Options.possible;
                        break;


                }
                switch (ANeccesery.IsChecked)
                {
                    case true:
                        gr.AirConditoiner = Options.neccesery;
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
                        gr.Jacuzzi = Options.notintersted;
                        break;

                }
                switch (JPossible.IsChecked)
                {
                    case true:
                        gr.Jacuzzi = Options.possible;
                        break;


                }
                switch (JNeccesery.IsChecked)
                {
                    case true:
                        gr.Jacuzzi = Options.neccesery;
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
                #region Free Parking
                switch (FNotintersted.IsChecked)
                {
                    case true:
                        gr.FreeParking = Options.notintersted;
                        break;

                }
                switch (FPossible.IsChecked)
                {
                    case true:
                        gr.FreeParking = Options.possible;
                        break;


                }
                switch (FNeccesery.IsChecked)
                {
                    case true:
                        gr.FreeParking = Options.neccesery;
                        break;


                }
                #endregion
                #region Room Service
                switch (RNotintersted.IsChecked)
                {
                    case true:
                        gr.RoomService = Options.notintersted;
                        break;

                }
                switch (RPossible.IsChecked)
                {
                    case true:
                        gr.RoomService = Options.possible;
                        break;


                }
                switch (RNeccesery.IsChecked)
                {
                    case true:
                        gr.RoomService = Options.neccesery;
                        break;


                }
                #endregion

                bl.AddRequest(gr);


                var thankPAGE = new ThankYouPage();
                this.NavigationService.Navigate(thankPAGE);


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
        private void HomeBTN_Click(object sender, RoutedEventArgs e)
        {
            var HOMEPAGE = new WelcomePage();
            this.NavigationService.Navigate(HOMEPAGE);

        }
    }
}































