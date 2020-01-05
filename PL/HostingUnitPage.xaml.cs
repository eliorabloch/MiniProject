using System;

using System.Windows;
using System.Windows.Controls;
using BE;
using BL;

namespace PL
{
   
    /// <summary>
    /// Interaction logic for hostingUnit.xaml
    /// </summary>
    public partial class HostingUnitPage : Page
    {
        bool m_isEdit = false;
        Host m_Owner { get; set; }

        public HostingUnitPage(Host owner, bool isEdit, int key=-1)
        {
            InitializeComponent();
            m_Owner = owner;
            if (isEdit)
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
                m_isEdit = true;
            }

        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ImpBL bl = ImpBL.Instance;
            HostingUnit hu = new HostingUnit();
            hu.HostingUnitName = HostinUnitNameTextBox.Text;
            hu.Area = (BE.Areas)AreaComboBox.SelectedIndex;
            hu.Type = (BE.UnitType)AreaComboBox.SelectedIndex;
            hu.SubArea = SubAreaTextBox.Text;
            switch (AreaComboBox.SelectedIndex)
            {
                case 0:
                    hu.Area = Areas.Jerusalem;
                    break;
                case 1:
                    hu.Area = Areas.Center;

                    break;
                case 2:
                    hu.Area = Areas.North;
                    break;
                case 3:
                    hu.Area = Areas.South;

                    break;
                default:
                    break;
            }
            switch (UnitTypeComboBox.SelectedIndex)
            {
                case 0:
                    hu.Type = UnitType.Tzimer;
                    break;
                case 1:
                    hu.Type = UnitType.HostingUnit;

                    break;
                case 2:
                    hu.Type = UnitType.HotelRoom;

                    break;
                case 3:
                    hu.Type = UnitType.Tent;

                    break;
                default:
                    break;
            }

            hu.Pool = (bool)HasPoolCheckBox.IsChecked;
            hu.Jacuzz = (bool)HasJacuzzCheckBox.IsChecked;
            hu.Garden = (bool)HasGardanCheckBox.IsChecked;
            hu.ChildrensAttractions = (bool)HasChildrenAttractionsCheckBox.IsChecked;
            hu.Owner = m_Owner;

            if (m_isEdit)
            {
                int hostingUnitKey = int.Parse(HostingUnitKeyLable.Content.ToString().Substring(1));
                hu.HostingUnitKey = hostingUnitKey;
                bl.UpdateUnit(hu);
                HostinUnitListPage obj = new HostinUnitListPage(hu.Owner, this.NavigationService);
                this.NavigationService.Navigate(obj);
            }

            else
            {
                bl.AddUnit(hu);

                HostinUnitListPage obj = new HostinUnitListPage(hu.Owner, this.NavigationService);
                this.NavigationService.Navigate(obj);

            }

        }

        private void HostInfoBTN_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                HostInformationPage huw = new HostInformationPage(m_Owner);
                this.NavigationService.Navigate(huw);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UnitTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }

