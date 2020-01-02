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
                    Adults = "2",
                    Area = Areas.Jerusalem,
                    Children = "7",
                    ChildrensAttractions = Options.neccesery,
                    EntryDate = new DateTime(2020, 7, 1),
                    ReleaseDate = new DateTime(2020, 8, 2),
                    FamilyName = "Cohen",
                    PrivateName = "Moshe",
                    Garden = Options.neccesery,
                    Jacuzz =  Options.possible,
                    MailAddress = "mosheCohen@gmail.com",
                    PhoneNumber="0545556678",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Mamila",
                    Type = UnitType.HotelRoom
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "2",
                    Area = Areas.Center,
                    Children = "9",
                    ChildrensAttractions = Options.neccesery,
                    EntryDate = new DateTime(2020, 1, 11),
                    ReleaseDate = new DateTime(2020, 1, 20),
                    FamilyName = "Maman",
                    PrivateName = "Yael",
                    Garden = Options.possible,
                    Jacuzz =  Options.notintersted,
                    MailAddress = "Mamanyaelll9090@gmail.com",
                    PhoneNumber="0546390909",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Tel-Aviv",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "3",
                    Area = Areas.South,
                    Children = "0",
                    ChildrensAttractions = Options.notintersted,
                    EntryDate = new DateTime(2020, 9, 1),
                    ReleaseDate = new DateTime(2020, 9, 2),
                    FamilyName = "Levi",
                    PrivateName = "Eden",
                    Garden = Options.notintersted,
                    Jacuzz =  Options.possible,
                    MailAddress = "eden0542225291@gmail.com",
                    PhoneNumber="0542225291",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Meztada",
                    Type = UnitType.Tzimer
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "2",
                    Area = Areas.South,
                    Children = "9",
                    ChildrensAttractions = Options.possible,
                    EntryDate = new DateTime(2020, 1, 1),
                    ReleaseDate = new DateTime(2020, 1, 2),
                    FamilyName = "Bloch",
                    PrivateName = "Eli",
                    Garden = Options.neccesery,
                    Jacuzz =  Options.possible,
                    MailAddress = "eliorab@walla.com",
                    PhoneNumber="0511125291",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Ramat-HaGolan",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "2",
                    Area = Areas.Center,
                    Children = "2",
                    ChildrensAttractions = Options.neccesery,
                    EntryDate = new DateTime(2020, 8, 1),
                    ReleaseDate = new DateTime(2020, 8, 6),
                    FamilyName = "Israeli",
                    PrivateName = "Tal",
                    Garden = Options.notintersted,
                    Jacuzz =  Options.possible,
                    MailAddress = "taltal24@walla.com",
                    PhoneNumber="0546300091",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Givat shmuel",
                    Type = UnitType.HostingUnit
                },

                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "3",
                    Area = Areas.Center,
                    Children = "9",
                    ChildrensAttractions = Options.neccesery,
                    EntryDate = new DateTime(2020, 1, 1),
                    ReleaseDate = new DateTime(2020, 1, 2),
                    FamilyName = "Edri",
                    PrivateName = "Sara",
                    Garden = Options.notintersted,
                    Jacuzz =  Options.possible,
                    MailAddress = "saraush1999@gamil.com",
                    PhoneNumber="0546345291",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Tel-Aviv",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "5",
                    Area = Areas.Jerusalem,
                    Children = "9",
                    ChildrensAttractions = Options.possible,
                    EntryDate = new DateTime(2020, 1, 1),
                    ReleaseDate = new DateTime(2020, 1, 4),
                    FamilyName = "Orenstein",
                    PrivateName = "Liel",
                    Garden = Options.notintersted,
                    Jacuzz =  Options.possible,
                    MailAddress = "lialorenstein10@gmail.com",
                    PhoneNumber="0546345555",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Ramot",
                    Type = UnitType.HotelRoom
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "2",
                    Area = Areas.North,
                    Children = "5",
                    ChildrensAttractions = Options.neccesery,
                    EntryDate = new DateTime(2020,2, 1),
                    ReleaseDate = new DateTime(2020, 2, 4),
                    FamilyName = "Bloch",
                    PrivateName = "Yinon",
                    Garden = Options.notintersted,
                    Jacuzz =  Options.possible,
                    MailAddress = "yinonnn@gmail.com",
                    PhoneNumber="0546745555",
                    Pool = Options.notintersted,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Tzfat",
                    Type = UnitType.Tzimer
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults =" 2",
                    Area = Areas.South,
                    Children = "1",
                    ChildrensAttractions = Options.notintersted,
                    EntryDate = new DateTime(2019, 01, 12),
                    ReleaseDate = new DateTime(2019, 01,15),
                    FamilyName = "Fridman",
                    PrivateName = "Ronit",
                    Garden = Options.possible,
                    Jacuzz =  Options.notintersted,
                    MailAddress = "fridmanRRR@walla.com",
                    PhoneNumber="0546341234",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
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
                    ChildrensAttractions = true,
                    HostingUnitName = "Dan",
                    SubArea = "Tel-Aviv",
                    Jacuzz = true,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="rami",
                        FamilyName="Bloch",
                        HostId="1",
                        PhoneNumber="0547648500",
                        CollectionClearance=true,
                        MailAddress="ramidan@gmail.com",
                        BankAccountNumber="009863673795",
                    }
                },
                new HostingUnit
                {
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                   // Diary = BE.Utils.createMatrix(),
                    Pool = true,
                    ChildrensAttractions = true,
                    HostingUnitName = "Plaza",
                    SubArea = "Herzelia",
                    Jacuzz = false,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="Moshe",
                        FamilyName="lo",
                        HostId="2",
                        PhoneNumber="0548866123",
                        CollectionClearance=true,
                        MailAddress="lomoshe@gmail.com",
                        BankAccountNumber="345565657789",
                    }
                },
                 new HostingUnit
                {
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Jerusalem,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Leonardo",
                    SubArea = "Mamila",
                    Jacuzz = true,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="Olivia",
                        FamilyName="Coch",
                        HostId="3",
                         PhoneNumber="0533345217",
                        CollectionClearance=true,
                        MailAddress="oliviacoch@gmail.com",
                        BankAccountNumber="905000087600",
                    }
                },
                 new HostingUnit
                {  // Diary=BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Jerusalem,
                    Pool = true,
                    ChildrensAttractions = true,
                    HostingUnitName = "hotel",
                    SubArea = "Mamila",
                    Garden=true,
                    Jacuzz = true,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="LielAndEli",
                        FamilyName="OrensteinAndBloch",
                        HostId="8",
                        CollectionClearance=true,
                        MailAddress="elielhotel2020@gmail.com",
                        PhoneNumber="0546547645",
                        BankAccountNumber="456678951232",
                    }
                },
                  new HostingUnit
                {
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.South,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Pnina tzimmer",
                    SubArea = "Eilat",
                    Jacuzz = true,
                    Type = UnitType.HostingUnit,
                    Owner= new Host
                    {
                        PrivateName="Pnina",
                        FamilyName="Lev",
                        HostId="4",
                         PhoneNumber="0523345643",
                        CollectionClearance=true,
                        MailAddress="pninaeilat@gmail.com",
                        BankAccountNumber="678888543000",
                    }
                },
                   new HostingUnit
                {
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.North,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Shimony",
                    SubArea = "Tzaft",
                    Jacuzz = false,
                    Type = UnitType.Tzimer,
                    Owner= new Host
                    {
                        PrivateName="Shimon",
                        FamilyName="Baruch",
                        HostId="5",
                         PhoneNumber="0588897545",
                        CollectionClearance=true,
                        MailAddress="baruch@gmail.com",
                        BankAccountNumber="678787990043",
                    }
                },

                 new HostingUnit
                {
                   HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.South,
                    Pool = true,
                    ChildrensAttractions = true,
                    HostingUnitName = "Sami",
                    SubArea = "Eilat",
                    Jacuzz = true,
                    Type = UnitType.Tent,
                     Owner= new Host
                    {
                        PrivateName="Sami",
                        FamilyName="Oren",
                        HostId="6",
                        PhoneNumber="0587712340",
                        CollectionClearance=true,
                        MailAddress="tentforrent@gmail.com",
                        BankAccountNumber="098334549877",
                    }
                },
                  new HostingUnit
                {
                   HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Blue sky",
                    SubArea = "Petach tikva",
                    Jacuzz = true,
                    Type = UnitType.Tzimer,
                     Owner= new Host
                    {
                        PrivateName="Nechama",
                        FamilyName="Israel",
                        HostId="7",
                         PhoneNumber="0548823450",
                        CollectionClearance=true,
                        MailAddress="petachtikvatzimer@gmail.com",
                        BankAccountNumber="009821454432",
                    }
                },
                   new HostingUnit
                {
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = true,
                    HostingUnitName = "Eliel hotel",
                    SubArea = "Tel-aviv",
                    Jacuzz = true,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="LielAndEli",
                        FamilyName="OrensteinAndBloch",
                        HostId="8",
                        CollectionClearance=true,
                        MailAddress="elielhotel2020@gmail.com",
                        PhoneNumber="0546547645",
                        BankAccountNumber="456678951232",
                    }
                },
                   new HostingUnit
                {
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = false,
                    ChildrensAttractions = true,
                    HostingUnitName = "Nechama",
                    SubArea = "Petach tikva",
                    Jacuzz = false,
                    Type = UnitType.HostingUnit,
                    Owner= new Host
                    {
                        PrivateName="Nechama",
                        FamilyName="Israel",
                        HostId="7",
                        PhoneNumber="0548823450",
                        CollectionClearance=true,
                        MailAddress="petachtikvatzimer@gmail.com",
                        BankAccountNumber="009821454432",
                    }
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
                },
                  new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000002,
                    HostingUnitKey = 100000002,
                    Status = OrderStatus.SentMail
                },
                   new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000003,
                    HostingUnitKey = 100000003,
                    Status = OrderStatus.SentMail
                },
                    new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000004,
                    HostingUnitKey = 100000004,
                    Status = OrderStatus.SentMail
                },
                     new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000005,
                    HostingUnitKey = 100000005,
                    Status = OrderStatus.SentMail
                },
                      new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000006,
                    HostingUnitKey = 100000006,
                    Status = OrderStatus.SentMail
                },
                       new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000007,
                    HostingUnitKey = 100000007,
                    Status = OrderStatus.SentMail
                },
            };

        }
    }
}