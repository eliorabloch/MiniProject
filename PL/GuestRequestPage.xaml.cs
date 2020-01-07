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


                {
                    ImpBL bl = ImpBL.Instance;
                    GuestRequest gr = new GuestRequest();
                    gr.Status = RequestStatus.Open;
                    gr.RegistrationDate=DateTime.Now;


                   

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

                    gr.Type = (UnitType)Enum.Parse(typeof(UnitType), TypeComboBox.SelectedValue.ToString(), true);

                    
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
                   

                    var thankPAGE = new ThankYouPage();
                    this.NavigationService.Navigate(thankPAGE);

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































