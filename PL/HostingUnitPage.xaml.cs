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
using BE;
using BL;
using System.Globalization;

namespace PL
{
   
    /// <summary>
    /// Interaction logic for hostingUnit.xaml
    /// </summary>
    public partial class HostingUnitPage : Page
    {
        bool m_isEdit = false;
        Host m_Owner { get; set; }
        HostingUnit m_hostingUnit { get; set; }
        public HostingUnitPage(Host owner, HostingUnit hu=null)
        {
            InitializeComponent();
            
            m_Owner = owner;
            m_hostingUnit = hu;
            try
            {
                if (hu != null)
                {
                    DataContext = hu;
                    //HostinUnitNameTextBox.Text = hu.HostingUnitName;
                    //SubAreaTextBox.Text = hu.SubArea;
                    //HostingUnitKeyLable.Content = "#" + hu.HostingUnitKey;

                    HasChildrenAttractionsCheckBox.IsChecked = hu.ChildrensAttractions;
                    HasGardanCheckBox.IsChecked = hu.Garden;
                    HasPoolCheckBox.IsChecked = hu.Pool;
                    HasJacuzzCheckBox.IsChecked = hu.Jacuzz;
                    AirConditionerCheckBox.IsChecked    = hu.AirConditoiner;
                    FreeParkingCheckBox.IsChecked = hu.FreeParking;
                    BreakFastIncludedcheckBox.IsChecked = hu.breakfastIncluded;
                    RoomServiceCheckBox.IsChecked = hu.RoomService;

                   
                    switch (hu.RateStars)
                    {
                        case 1:
                            oneStar.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            oneStar.Visibility = Visibility.Visible;
                            TwoStar.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            oneStar.Visibility = Visibility.Visible;

                            TwoStar.Visibility = Visibility.Visible;
                            ThreeStar.Visibility = Visibility.Visible;
                            break;

                        case 4:
                            oneStar.Visibility = Visibility.Visible;
                            TwoStar.Visibility = Visibility.Visible;
                            ThreeStar.Visibility = Visibility.Visible;
                            FourStar.Visibility = Visibility.Visible;
                            break;

                        case 5:
                            oneStar.Visibility = Visibility.Visible;
                            TwoStar.Visibility = Visibility.Visible;
                            ThreeStar.Visibility = Visibility.Visible;
                            FourStar.Visibility = Visibility.Visible;
                            FiveStar.Visibility = Visibility.Visible;

                            break;
                        default:
                            break;
                    }

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

                    ImpBL bl = ImpBL.Instance;
                    foreach (var item in bl.markTakenDatesInMatrix(hu))
                    {
                        takenDatesCalender.BlackoutDates.Add(new CalendarDateRange(item.Item1, item.Item2));
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }
        

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ImpBL bl = ImpBL.Instance;
            HostingUnit hu = m_hostingUnit == null ? new HostingUnit() : m_hostingUnit;
            try
            {
                hu.HostingUnitName = HostinUnitNameTextBox.Text;
                if (hu.HostingUnitName == "")
                {
                    throw new TzimerException("Must enter a name for the unit!");
                }
                hu.Area = (BE.Areas)AreaComboBox.SelectedIndex;
                hu.Type = (BE.UnitType)AreaComboBox.SelectedIndex;
                hu.SubArea = SubAreaTextBox.Text;


                hu.AirConditoiner =    (bool)AirConditionerCheckBox.IsChecked;
                hu.FreeParking    =    (bool)FreeParkingCheckBox.IsChecked;
                hu.breakfastIncluded = (bool)BreakFastIncludedcheckBox.IsChecked;
                hu.RoomService=        (bool)RoomServiceCheckBox.IsChecked;

                if (hu.SubArea == "")
                {
                    throw new TzimerException("Must enter a sub area for your unit!");
                }
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
                    bl.UpdateHostingUnit(hu);
                    HostinUnitListPage obj = new HostinUnitListPage(hu.Owner, this.NavigationService);
                    this.NavigationService.Navigate(obj);
                }

                else
                {
                    bl.AddHostingUnit(hu);

                    HostinUnitListPage obj = new HostinUnitListPage(hu.Owner, this.NavigationService);
                    this.NavigationService.Navigate(obj);

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void HostInfoBTN_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                HostInformationPage huw = new HostInformationPage(m_Owner, m_hostingUnit);
                this.NavigationService.Navigate(huw);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HasJacuzzCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void HomeBTN_Click(object sender, RoutedEventArgs e)
        {
            var HOMEPAGE = new WelcomePage();
            this.NavigationService.Navigate(HOMEPAGE);

        }

    }

    public partial class HostingUnitKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "#" + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return int.Parse(value.ToString().Substring(1));
        }
    }


}
