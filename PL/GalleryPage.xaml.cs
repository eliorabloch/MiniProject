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
using BL;

namespace PL
{
    /// <summary>
    /// Interaction logic for GalleryPage.xaml
    /// </summary>
    public partial class GalleryPage : Page
    {
        public GalleryPage(NavigationService nav)
        {
            InitializeComponent();
            
          
            
            
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
