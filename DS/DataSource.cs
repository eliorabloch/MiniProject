using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class DataSource
    {
        public static List<GuestRequest> requestList;
        public static List<HostingUnit> unitList;
        public static List<Order> orderList;

        public DataSource()
        {
        }

        public static void Init()
        {
            // init guest requests
            requestList = new List<GuestRequest>
            {
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = 3,
                    Area = Areas.Center,
                    Children = 9,
                    ChildrensAttractions = Options.neccesery,
                    EntryDate = new DateTime(2020, 1, 1),
                    ReleaseDate = new DateTime(2020, 1, 4),
                    FamilyName = "Bloch",
                    PrivateName = "Eli",
                    Garden = Options.notintersted,
                    Jacuzz =  Options.possible,
                    MailAddress = "a@a.com",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Tel-Aviv",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
                                        GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = 5,
                    Area = Areas.Jerusalem,
                    Children = 9,
                    ChildrensAttractions = Options.possible,
                    EntryDate = new DateTime(2020, 1, 1),
                    ReleaseDate = new DateTime(2020, 1, 4),
                    FamilyName = "Orenstein",
                    PrivateName = "Liel",
                    Garden = Options.notintersted,
                    Jacuzz =  Options.possible,
                    MailAddress = "l@a.com",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Ramot",
                    Type = UnitType.HotelRoom
                },
                new GuestRequest
                {
                                        GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = 2,
                    Area = Areas.North,
                    Children = 5,
                    ChildrensAttractions = Options.neccesery,
                    EntryDate = new DateTime(2020,2, 1),
                    ReleaseDate = new DateTime(2020, 2, 4),
                    FamilyName = "Bloch",
                    PrivateName = "Yinon",
                    Garden = Options.notintersted,
                    Jacuzz =  Options.possible,
                    MailAddress = "a@mmm.com",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.ExpiredRequest,
                    SubArea = "Tzfat",
                    Type = UnitType.Tzimer
                },
                new GuestRequest
                {
                                        GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = 2,
                    Area = Areas.South,
                    Children = 1,
                    ChildrensAttractions = Options.notintersted,
                    EntryDate = new DateTime(2020, 3, 3),
                    ReleaseDate = new DateTime(2020, 4, 6),
                    FamilyName = "Fridman",
                    PrivateName = "Ronit",
                    Garden = Options.possible,
                    Jacuzz =  Options.notintersted,
                    MailAddress = "a@a.com",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.ClosedDeal,
                    SubArea = "Eilat",
                    Type = UnitType.Tent
                }
            };
            
            // init hosting units list
            unitList = new List<HostingUnit>
            {
                new HostingUnit
                {
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Hello kiti",
                    SubArea = "ttt",
                    Jacuzz = true,
                    Type = UnitType.HostingUnit
                },
                 new HostingUnit
                {
                                         HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Sami",
                                        SubArea = "ttt",
                    Jacuzz = true,
                    Type = UnitType.Tent
                },
                  new HostingUnit
                {
                                          HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Blue sky",
                                        SubArea = "ttt",
                    Jacuzz = true,
                    Type = UnitType.Tzimer
                },
                   new HostingUnit
                {
                                           HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Eliel hotel",
                                        SubArea = "ttt",
                    Jacuzz = true,
                    Type = UnitType.HotelRoom
                }
            };


            // init order list
            orderList = new List<Order>
            {
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000000,
                    HostingUnitKey = 100000000,
                    Status = OrderStatus.SentMail
                },
                 new Order
                {
                                         OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000001,
                    HostingUnitKey = 100000001,
                    Status = OrderStatus.SentMail
                }
            };

        }
    }
}
