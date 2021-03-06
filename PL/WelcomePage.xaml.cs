﻿using System;
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
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        NavigationService m_navigationService { get; set; }
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void GeustRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            m_navigationService = this.NavigationService;
            var GuestRequestPage = new GuestRequestListPage(m_navigationService); //create your new form.
            this.NavigationService.Navigate(GuestRequestPage);

        }

        private void HostingUnitBTN_Click(object sender, RoutedEventArgs e)
        {
            var HostLoginPage = new HostLoginPage(); //create your new form.
            this.NavigationService.Navigate(HostLoginPage);
            //this.Content = HostLoginPage;
        }

        private void MannagerBtn_Click(object sender, RoutedEventArgs e)
        {
            MannagerBtn.Visibility = Visibility.Collapsed;
            Paasword.Visibility = Visibility.Visible;
            LoginBtn.Visibility = Visibility.Visible;

      
        }
    
           


        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ratingunitpage = new RateUnitPage(m_navigationService); //create your new form.
            this.NavigationService.Navigate(ratingunitpage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var galleryPage = new GalleryPage(m_navigationService); //create your new form.
            this.NavigationService.Navigate(galleryPage);
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(PASSWORD.Password == "12345"))
            {
                string titel = "Sorry";
                string err = "Wrong Password,please try again!";
                MessageBox.Show(err,titel);
                return;
            }

            MannagerBtn.Visibility = Visibility.Visible;
            Paasword.Visibility = Visibility.Collapsed;
            LoginBtn.Visibility = Visibility.Collapsed;
            m_navigationService = this.NavigationService;
            var ManagerPage = new ManagerPage(m_navigationService); //create your new form.
            this.NavigationService.Navigate(ManagerPage);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ContactGrid.Visibility = Visibility.Visible;
            contactBtn.Visibility = Visibility.Collapsed;
            rateunitsBTN.Visibility = Visibility.Collapsed;
            galleryBtn.Visibility = Visibility.Collapsed;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void exutBTN_Click(object sender, RoutedEventArgs e)
        {
            ContactGrid.Visibility = Visibility.Collapsed;
            contactBtn.Visibility = Visibility.Visible;
            rateunitsBTN.Visibility = Visibility.Visible;
            galleryBtn.Visibility = Visibility.Visible;
        }
    }
}
