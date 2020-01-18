using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml.Linq;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(!File.Exists("Config.xml"))
            {
                XElement xElement = new XElement("Config");
                xElement.Add(new XElement("GuestRequestId", "100000000"));
                xElement.Add(new XElement("HostingUnitId", "100000000"));
                xElement.Add(new XElement("OrderId", "100000000"));
                xElement.Add(new XElement("Commissin", "10"));
                xElement.Add(new XElement("Profits", "0"));
                xElement.Save("Config.xml");
            }
            if (!File.Exists("HostingUnits.xml"))
            {
                XElement xElement = new XElement("HostingUnits");
                xElement.Save("HostingUnits.xml");
            }
            if (!File.Exists("GuestRequests.xml"))
            {
                XElement xElement = new XElement("GuestRequests");
                xElement.Save("GuestRequests.xml");
            }
            if (!File.Exists("Orders.xml"))
            {
                XElement xElement = new XElement("Orders");
                xElement.Save("Orders.xml");
            }
            MainFrame.NavigationService.Navigate(new BootingPage());
        }

        
    }
}
