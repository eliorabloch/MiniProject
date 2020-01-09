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
    /// Interaction logic for RateUnitPage.xaml
    /// </summary>
    public partial class RateUnitPage : Page
    {
        public RateUnitPage(NavigationService nav)
        {
            InitializeComponent();
            List<RatingUnitItemControl> RatingControl = new List<RatingUnitItemControl>();
            ImpBL bl = ImpBL.Instance;
            foreach (var item in bl.GetUnitsList())
            {
                RatingUnitItemControl uic = new RatingUnitItemControl();
                uic.idLable.Content = item.HostingUnitKey;
               
                uic.unitNameLable.Content = item.HostingUnitName;
                
                
                RatingControl.Add(uic);
            }
            ratingListView.ItemsSource = RatingControl;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
