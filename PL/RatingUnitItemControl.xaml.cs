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
    /// Interaction logic for RatingUnitItemControl.xaml
    /// </summary>
    public partial class RatingUnitItemControl : UserControl
    {
        public RatingUnitItemControl()
        {
            InitializeComponent();
            
            
        }

        private void oneStarBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateRate(1);
        }

        private void twoStarBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateRate(2);
        }

       

        private void threeStarBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateRate(3);
        }

        private void FOURsTARbtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateRate(4);
        }

        private void fiveStarBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateRate(5);
        }
        private void UpdateRate(int numStars)//rating stars function
        {
            ImpBL bl = ImpBL.Instance;
            int Key = int.Parse(idLable.Content.ToString());

            HostingUnit hu = bl.GetUnit(Key);
            hu.amountOfRaters++;
            hu.RateAmount += numStars;
            hu.RateStars = hu.RateAmount / hu.amountOfRaters;
            bl.UpdateUnit(hu);
        }
    }
}
