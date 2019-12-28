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
using BE;
using BL;

namespace PL
{
    /// <summary>
    /// Interaction logic for hostingUnit.xaml
    /// </summary>
    public partial class HostingUnitWindow : Window
    {
        public HostingUnitWindow()
        {
            InitializeComponent();
        }

        public HostingUnitWindow(bool isEdit, int key=-1)
        {
            InitializeComponent();
            if(isEdit)
            {
                ImpBL bl = ImpBL.Instance;
                HostingUnit hu = bl.GetUnit(key);
                HasChildrenAttractionsCheckBox.IsChecked = hu.ChildrensAttractions;
                HasGardanCheckBox.IsChecked = hu.Garden;
                HasPoolCheckBox.IsChecked = hu.Pool;
                HasJacuzzCheckBox.IsChecked = hu.Jacuzz;
                HostinUnitNameTextBox.Text = hu.HostingUnitName;
                HostingUnitKeyLable.Content = "#" + hu.HostingUnitKey;
                SubAreaTextBox.Text = hu.SubArea;

                switch (hu.Area)
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

                switch (hu.Type)
                {
                    case UnitType.Tzimer:
                        UnitTypeComboBox.SelectedIndex = 0;
                        break;
                    case UnitType.HostingUnit:
                        UnitTypeComboBox.SelectedIndex = 1;
                        break;
                    case UnitType.HotelRoom:
                        UnitTypeComboBox.SelectedIndex = 2;
                        break;
                    case UnitType.Tent:
                        UnitTypeComboBox.SelectedIndex = 3;
                        break;
                    default:
                        break;
                }

            }

        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
