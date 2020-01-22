using BE;
using BL;
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
            if (!File.Exists("Config.xml"))
            {
                XElement xElement = new XElement("Config");
                xElement.Add(new XElement("GuestRequestId", "100000000"));
                xElement.Add(new XElement("HostingUnitId", "100000000"));
                xElement.Add(new XElement("OrderId", "100000000"));
                xElement.Add(new XElement("Commissin", "10"));
                xElement.Add(new XElement("Profits", "0"));
                xElement.Save("Config.xml");
            }
            if (!File.Exists("HostingUnits.xml") || string.IsNullOrEmpty(File.ReadAllText("HostingUnits.xml")))
            {
                XElement xElement = new XElement("ArrayOfHostingUnit");
                xElement.Save("HostingUnits.xml");
            }
            if (!File.Exists("GuestRequests.xml") || string.IsNullOrEmpty(File.ReadAllText("GuestRequests.xml")))
            {
                XElement xElement = new XElement("GuestRequests");
                xElement.Save("GuestRequests.xml");
            }
            if (!File.Exists("Orders.xml") || string.IsNullOrEmpty(File.ReadAllText("Orders.xml")))
            {
                XElement xElement = new XElement("Orders");
                xElement.Save("Orders.xml");
            }

            //ImpBL bl = ImpBL.Instance;
            //bl.AddUnit(new HostingUnit
            //{
            //    Diary = BE.Utils.createMatrix(),
            //    HostingUnitKey = Configuration.HostingUnitId++,
            //    Area = Areas.Center,
            //    Pool = true,
            //    FreeParking = true,
            //    breakfastIncluded = false,
            //    AirConditoiner = true,
            //    RoomService = false,
            //    RateAmount = 150,
            //    amountOfRaters = 30,
            //    RateStars = 150 / 30,

            //    Garden = false,
            //    ChildrensAttractions = false,
            //    HostingUnitName = "Blue sky",
            //    SubArea = "Petach tikva",
            //    Jacuzz = true,
            //    Type = UnitType.Tzimer,
            //    Owner = new Host
            //    {
            //        PrivateName = "Nechama",
            //        FamilyName = "Israel",
            //        HostId = "7",
            //        numOfUnits = 3,
            //        PhoneNumber = "0548823450",
            //        CollectionClearance = true,
            //        MailAddress = "petachtikvatzimer@gmail.com",
            //        BankAccountNumber = "009821454432",
            //    }
            //});


            MainFrame.NavigationService.Navigate(new BootingPage());
        }

        
    }
}
