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
            init();
        }

        private static void init()
        {
            // init guest requests
            requestList = new List<GuestRequest>
            {
                new GuestRequest
                {
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
                    Status = RequestStatus.Active,
                    SubArea = "Tel-Aviv",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
                    Adults = 5,
                    Area = Areas.Jerusalem,
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
                    Status = RequestStatus.Active,
                    SubArea = "Tel-Aviv",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
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
                    Status = RequestStatus.Active,
                    SubArea = "Tel-Aviv",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
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
                    Status = RequestStatus.Active,
                    SubArea = "Tel-Aviv",
                    Type = UnitType.HostingUnit
                }
            };



            // init hosting units list
            unitList = new List<HostingUnit>
            {
                new HostingUnit
                {
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Hello kiti",
                    Jacuzz = true,
                    Type = UnitType.HostingUnit
                },
                 new HostingUnit
                {
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Hello kiti",
                    Jacuzz = true,
                    Type = UnitType.HostingUnit
                },
                  new HostingUnit
                {
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Hello kiti",
                    Jacuzz = true,
                    Type = UnitType.HostingUnit
                },
                   new HostingUnit
                {
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Hello kiti",
                    Jacuzz = true,
                    Type = UnitType.HostingUnit
                }
            };


            // init order list
            orderList = new List<Order>
            {
                new Order
                {
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000000,
                    HostingUnitKey = 100000000,
                    Status = OrderStatus.SentMail
                },
                 new Order
                {
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000001,
                    HostingUnitKey = 100000001,
                    Status = OrderStatus.SentMail
                }
            };

        }
    }
}
