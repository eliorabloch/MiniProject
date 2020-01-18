﻿using BE;
using BL;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        HostingUnit m_hostingUnit;
        public OrderListPage(HostingUnit hostingUnit)
        {
            InitializeComponent();
            m_hostingUnit = hostingUnit;
            LoadLists();
        }

        public void LoadLists()
        {
            ImpBL bl = ImpBL.Instance;
            List<Order> Myorders = bl.GetOrdersByUnit(m_hostingUnit.HostingUnitKey);
            List<MyOrderItemControl> itemsToView = new List<MyOrderItemControl>();
            foreach (var order in Myorders)
            {
                itemsToView.Add(new MyOrderItemControl(order, this));
            }

            MyOrderListView.ItemsSource = itemsToView;

            List<GuestRequest> Suggestorders = bl.matchRequestToUnit(m_hostingUnit);
            List<SuggetionOrderItemControl> itemsToView2 = new List<SuggetionOrderItemControl>();
            foreach (var gr in Suggestorders)
            {
                itemsToView2.Add(new SuggetionOrderItemControl(gr, m_hostingUnit, this));
            }
            SuggestionListView.ItemsSource = itemsToView2;
        }

        private void SuggestionListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
