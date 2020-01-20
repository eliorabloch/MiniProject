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
using System.ComponentModel;

namespace PL
{
    /// <summary>
    /// Interaction logic for HostInformationWindow.xaml
    /// </summary>
    public partial class HostInformationPage : Page
    {
        private BackgroundWorker backgroundWorker1;
        List<BankBranch> branches;
        public HostInformationPage()
        {    
            try
            {
                InitializeComponent();
                getBanks();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public HostInformationPage(Host owner)
        {
            try
            {
                InitializeComponent();
                ImpBL bl = ImpBL.Instance;
                FirstNameTextBox.Text = owner.PrivateName;
               
                        
                LastNameTextBox.Text = owner.FamilyName;
               
                HostIdTextBox.Text = owner.HostId;
                int number;
                bool checknumber = Int32.TryParse(owner.HostId, out number);
                if (!checknumber)
                {
                    throw new TzimerException("Id number must not contain letters.");
                }



                    PhoneNumberTextBox.Text = owner.PhoneNumber;
                if (owner.PhoneNumber==""||owner.PhoneNumber==null)
                {
                    throw new TzimerException("Must enter a phone number!");
                }
                int number2;
                bool checknumber2 = Int32.TryParse(owner.PhoneNumber, out number2);
                if (!checknumber)
                {
                    throw new TzimerException("Phone number must contain only numbers.", "bl");

                }
                EmailTextBox.Text = owner.MailAddress;

                if (!(owner.MailAddress.Contains("@")))
                {
                    throw new TzimerException("E-mail Address format is invaled.Please enter the correct format.");
                }
                if (string.IsNullOrEmpty(owner.MailAddress))
                {
                    throw new TzimerException("Please enter your e-mail address.");
                }

                BankAccountNumberTextBox.Text = owner.BankAccountNumber;
                if (owner.BankAccountNumber==""||owner.BankAccountNumber==null)
                {
                    throw new TzimerException("Must enter a bank account number");
                }
                int number3;
                bool checknumber3 = Int32.TryParse(owner.PhoneNumber, out number3);
                if (!checknumber)
                {
                    throw new TzimerException("Bank account number must contain only numbers.");

                }
                
                collectoinCleearenceCheckBox.IsChecked = owner.CollectionClearance;
                BaranchesListComboBox.SelectedItem = owner.BankBranchDetails.BankName + " - " + owner.BankBranchDetails.BankNumber.ToString();

                tostringBox.Text = owner.BankBranchDetails.ToString();
                getBanks();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void getBanks()
        {
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_Completed;
            backgroundWorker1.RunWorkerAsync();

        }

        private void backgroundWorker1_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            branches = (List<BankBranch>)e.Result;
            foreach (var item in branches)
            {
                BaranchesListComboBox.Items.Add(item.BankName + " - " + item.BranchNumber);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ImpBL bl = ImpBL.Instance;
            e.Result = bl.GetBankList();
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
                if (hu.Owner.PrivateName == "" || hu.Owner.PrivateName == null)
                { throw new TzimerException("Must enter a private name!"); }
                hu.Owner.FamilyName = LastNameTextBox.Text;
                if (hu.Owner.FamilyName == null|| hu.Owner.FamilyName == "")
                { throw new TzimerException("Must enter a family name!"); }
                hu.Owner.HostId = HostIdTextBox.Text;
                hu.Owner.PhoneNumber = PhoneNumberTextBox.Text;
                hu.Owner.MailAddress = EmailTextBox.Text;
                hu.Owner.BankAccountNumber = BankAccountNumberTextBox.Text;
                hu.Owner.CollectionClearance = (bool)collectoinCleearenceCheckBox.IsChecked;

                HostingUnitPage obj = new HostingUnitPage(hu.Owner, false);
                this.NavigationService.Navigate(obj);
                string branchNumber = BaranchesListComboBox.SelectedValue.ToString().Split('-')[1].Trim();
                int branchNum = int.Parse(branchNumber);
                hu.Owner.BankBranchDetails = branches?.FirstOrDefault(x => x.BranchNumber == branchNum);

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

        private void bankInfo_Click(object sender, RoutedEventArgs e)
        {

            tostringBox.Visibility = Visibility.Visible;
            exitbtn.Visibility = Visibility.Visible;
            
        }

       

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {

            tostringBox.Visibility = Visibility.Hidden;
            exitbtn.Visibility = Visibility.Hidden;

        }
    }
}

