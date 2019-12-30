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
    /// Interaction logic for HostInformationWindow.xaml
    /// </summary>
    public partial class HostInformationPage : Page

    {
        int hostId = 0;
        bool isToEdit = false;
        public HostInformationPage()
        {
            InitializeComponent();

        }
        public HostInformationPage(Host owner)
        {
            InitializeComponent();
            ImpBL bl = ImpBL.Instance;
            FirstNameTextBox.Text = owner.PrivateName;
            LastNameTextBox.Text = owner.FamilyName;
            HostIdTextBox.Text = owner.HostId;
            PhoneNumberTextBox.Text = owner.PhoneNumber;
            EmailTextBox.Text = owner.MailAddress;
            BankAccountNumberTextBox.Text = owner.BankAccountNumber;
            collectoinCleearenceCheckBox.IsChecked = owner.CollectionClearance;
        }


        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImpBL bl = ImpBL.Instance;
                HostingUnit hu = new HostingUnit();
                hu.Owner = new Host();
                hu.Owner.PrivateName = FirstNameTextBox.Text;
                hu.Owner.FamilyName = LastNameTextBox.Text;
                hu.Owner.HostId = HostIdTextBox.Text;
                hu.Owner.PhoneNumber = PhoneNumberTextBox.Text;
                hu.Owner.MailAddress = EmailTextBox.Text;
                hu.Owner.BankAccountNumber = BankAccountNumberTextBox.Text;
                hu.Owner.CollectionClearance = (bool)collectoinCleearenceCheckBox.IsChecked;

                HostingUnitPage obj = new HostingUnitPage(hu.Owner, false);
                this.NavigationService.Navigate(obj);
                
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
    }
}

