using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using BL;


namespace PL
{
    /// <summary>
    /// Interaction logic for GuestRequestItemControl.xaml
    /// </summary>
    public partial class GuestRequestItemControl : UserControl
    {
 
           NavigationService m_navigationService { get; set; }
        public GuestRequestItemControl(NavigationService navigationService)
        {
            try
            {
                InitializeComponent();
                m_navigationService = navigationService;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteHostingUnitBtn_Click(object sender, RoutedEventArgs e)
        {
           


            try
            {
                ImpBL bl = ImpBL.Instance;
                int GuestRequestKey = int.Parse(GuestRequestKeyLable.Content.ToString().Substring(1));
                bl.DeleteRequest(bl.GetGuestRequest(GuestRequestKey));
                UserControlContainer.Visibility = Visibility.Collapsed;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private static MessageBoxButtons GetYesNo()
        {
            return MessageBoxButtons.YesNo;
        }

        private void RequestInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImpBL bl = ImpBL.Instance;
                int GuestRequestKey = int.Parse(GuestRequestKeyLable.Content.ToString().Substring(1));
                var GuestRequestPage = new GuestRequestInfoPage(GuestRequestKey); //create your new form.
                m_navigationService.Navigate(GuestRequestPage);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private class DialogResult
        {
        }
    }
}
