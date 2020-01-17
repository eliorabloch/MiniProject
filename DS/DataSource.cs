﻿using BE;
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
                    EntryDate = new DateTime(2020, 7, 1),
                    ReleaseDate = new DateTime(2020, 8, 2),
                    FamilyName = "Cohen",
                    PrivateName = "Moshe",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.possible,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.neccesery,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "mosheCohen@gmail.com",
                    PhoneNumber="0545556678",
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
                    Jacuzzi =  Options.notintersted,
                    MailAddress = "Mamanyaelll9090@gmail.com",
                    PhoneNumber="0546390909",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Tel-Aviv",
                    Type = UnitType.HostingUnit,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,

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
                      AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    FamilyName = "Levi",
                    PrivateName = "Eden",
                    Garden = Options.notintersted,
                    Jacuzzi =  Options.possible,
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
                    Area = Areas.North,
                    Children = "9",
                    ChildrensAttractions = Options.possible,
                    EntryDate = new DateTime(2020, 1, 1),
                    ReleaseDate = new DateTime(2020, 1, 2),
                    FamilyName = "Bloch",
                    PrivateName = "Eli",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.possible,
                      AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
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
                    Jacuzzi =  Options.possible,
                      AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
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
                    Jacuzzi =  Options.possible,
                    MailAddress = "saraush1999@gamil.com",
                    PhoneNumber="0546345291",
                    Pool = Options.possible,
                      AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
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
                    Jacuzzi =  Options.possible,
                      AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
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
                    Jacuzzi =  Options.possible,
                      AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
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
                    Jacuzzi =  Options.notintersted,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "fridmanRRR@walla.com",
                    PhoneNumber="0546341234",
                    Pool = Options.possible,
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Eilat",
                    Type = UnitType.Tent
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "8",
                    Area = Areas.Jerusalem,
                    Children = "7",
                    EntryDate = new DateTime(2020, 9, 19),
                    ReleaseDate = new DateTime(2020, 10, 2),
                    FamilyName = "Eisen",
                    PrivateName = "Liron",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.possible,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.neccesery,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.notintersted,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "Lironnnn@gmail.com",
                    PhoneNumber="0549056678",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Givat Shaul",
                    Type = UnitType.Tent
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "2",
                    Area = Areas.North,
                    Children = "0",
                    EntryDate = new DateTime(2020, 5, 1),
                    ReleaseDate = new DateTime(2020, 5, 5),
                    FamilyName = "Or",
                    PrivateName = "Lali",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.possible,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.notintersted,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.possible,
                    MailAddress = "lalior565656@gmail.com",
                    PhoneNumber="0546009678",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Golan",
                    Type = UnitType.Tzimer
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "1",
                    Area = Areas.Center,
                    Children = "4",
                    EntryDate = new DateTime(2020, 4, 11),
                    ReleaseDate = new DateTime(2020, 4, 20),
                    FamilyName = "Gilai",
                    PrivateName = "Halel",
                    Garden = Options.notintersted,
                    Jacuzzi =  Options.notintersted,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.neccesery,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.neccesery,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.neccesery,
                    MailAddress = "GilaiHalel98@gmail.com",
                    PhoneNumber="053423678",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Herzelia",
                    Type = UnitType.HotelRoom
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "3",
                    Area = Areas.Jerusalem,
                    Children = "0",
                    EntryDate = new DateTime(2020, 6, 21),
                    ReleaseDate = new DateTime(2020, 6, 26),
                    FamilyName = "Levi",
                    PrivateName = "Lee",
                    Garden = Options.possible,
                    Jacuzzi =  Options.possible,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.notintersted,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "lee0522345455@gmail.com",
                    PhoneNumber="0522345455",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Givat Mordechay",
                    Type = UnitType.HotelRoom
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "4",
                    Area = Areas.Center,
                    Children = "7",
                    EntryDate = new DateTime(2020, 7, 15),
                    ReleaseDate = new DateTime(2020, 7, 17),
                    FamilyName = "Klein",
                    PrivateName = "Tal",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.notintersted,
                    Pool = Options.notintersted,
                    ChildrensAttractions = Options.neccesery,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "Kleinfamily@walla.com",
                    PhoneNumber="0556609343",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Ramat Gan",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "3",
                    Area = Areas.South,
                    Children = "2",
                    EntryDate = new DateTime(2020, 9, 1),
                    ReleaseDate = new DateTime(2020, 9, 5),
                    FamilyName = "Tzur",
                    PrivateName = "Yarden",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.notintersted,
                    Pool = Options.notintersted,
                    ChildrensAttractions = Options.notintersted,
                    AirConditoiner=Options.notintersted,
                    RoomService=Options.notintersted,
                    FreeParking=Options.notintersted,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "Yardenushhht@gmail.com",
                    PhoneNumber="0585667824",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Beer Sheva",
                    Type = UnitType.Tent
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "2",
                    Area = Areas.South,
                    Children = "0",
                    EntryDate = new DateTime(2020, 8, 23),
                    ReleaseDate = new DateTime(2020, 8, 27),
                    FamilyName = "Vizel",
                    PrivateName = "Amit",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.possible,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.notintersted,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "mosheCohen@gmail.com",
                    PhoneNumber="0545623786",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Eilat",
                    Type = UnitType.HotelRoom
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "2",
                    Area = Areas.Center,
                    Children = "3",
                    EntryDate = new DateTime(2020, 5, 14),
                    ReleaseDate = new DateTime(2020, 5, 20),
                    FamilyName = "Levi",
                    PrivateName = "Moriya",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.possible,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.neccesery,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "mosheCohen@gmail.com",
                    PhoneNumber="0540996678",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Rehovot",
                    Type = UnitType.HostingUnit
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "1",
                    Area = Areas.South,
                    Children = "0",
                    EntryDate = new DateTime(2020, 7, 11),
                    ReleaseDate = new DateTime(2020, 8, 12),
                    FamilyName = "Mosh",
                    PrivateName = "Kobi",
                    Garden = Options.notintersted,
                    Jacuzzi =  Options.notintersted,
                    Pool = Options.notintersted,
                    ChildrensAttractions = Options.notintersted,
                    AirConditoiner=Options.notintersted,
                    RoomService=Options.notintersted,
                    FreeParking=Options.neccesery,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "kobimosh78@gmail.com",
                    PhoneNumber="0549056678",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Metzada",
                    Type = UnitType.Tent
                },
                new GuestRequest
                {
                    GuestRequestKey = Configuration.GuestRequestId++,
                    Adults = "2",
                    Area = Areas.Jerusalem,
                    Children = "1",
                    EntryDate = new DateTime(2020, 7, 1),
                    ReleaseDate = new DateTime(2020, 8, 2),
                    FamilyName = "Cohen",
                    PrivateName = "Yair",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.possible,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.neccesery,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "mosheCohen@gmail.com",
                    PhoneNumber="0523456780",
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
                    Children = "7",
                    EntryDate = new DateTime(2020, 6, 21),
                    ReleaseDate = new DateTime(2020, 6, 22),
                    FamilyName = "Malka",
                    PrivateName = "Efrat",
                    Garden = Options.neccesery,
                    Jacuzzi =  Options.possible,
                    Pool = Options.possible,
                    ChildrensAttractions = Options.neccesery,
                    AirConditoiner=Options.neccesery,
                    RoomService=Options.notintersted,
                    FreeParking=Options.possible,
                    breakfastIncluded=Options.notintersted,
                    MailAddress = "malkaefrat@walla.com",
                    PhoneNumber="0500056678",
                    RegistrationDate = DateTime.Now,
                    Status = RequestStatus.Open,
                    SubArea = "Netanya",
                    Type = UnitType.HostingUnit
                }
            };

            // init hosting units list
            unitList = new List<HostingUnit>
            {
                new HostingUnit
                {    
                    
                    
                    
                    
                    
                      
                   
                   
                   
                   
                  
                  
                    Diary =BE.Utils.createMatrix(),
                RateAmount=150,
                amountOfRaters=70,
                   RateStars=150/70,
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.South,
                    Pool = true,
                    ChildrensAttractions = false,
                    HostingUnitName = "Dan",
                    SubArea = "Tel-Aviv",
                    Jacuzz = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,

                    Garden=false,
                    Type = UnitType.Tzimer,
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
                    Diary = BE.Utils.createMatrix(),
                    FreeParking=true,
                    RateAmount=200,
                amountOfRaters=50,
                    RateStars=200/50,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    Pool = true,
                    Garden=false,
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
                { Diary=BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Jerusalem,
                    Pool = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    RateAmount=300,
                amountOfRaters=80,
                    RateStars=300/80,
                    Garden=false,
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
                {   Diary=BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Jerusalem,
                    Pool = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    RateAmount=400,
                amountOfRaters=100,
                     RateStars=400/100,
                    Garden=false,
                    ChildrensAttractions = true,
                    HostingUnitName = "hotel",
                    SubArea = "Mamila",

                    Jacuzz = true,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="Lieli",
                        FamilyName="Ob",
                        HostId="8",
                        CollectionClearance=true,
                        MailAddress="elielhotel2020@gmail.com",
                        PhoneNumber="0546547645",
                        BankAccountNumber="456678951232",
                    }
                },
                new HostingUnit
                { Diary=BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.South,
                    Pool = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    RateAmount=700,
                amountOfRaters=150,
                     RateStars=700/150,
                    Garden=false,
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
                { Diary=BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.North,
                    Pool = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/7,
                    Garden=false,
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
                {Diary=BE.Utils.createMatrix(),
                   HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.South,
                    Pool = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    RateAmount=180,
                amountOfRaters=70,
                     RateStars=180/70,
                    Garden=false,
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
                {Diary=BE.Utils.createMatrix(),
                   HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,

                    Garden=false,
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
                {Diary=BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    Garden=false,
                    ChildrensAttractions = true,
                    HostingUnitName = "Eliel hotel",
                    SubArea = "Tel-aviv",
                    Jacuzz = true,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="Lieli",
                        FamilyName="Ob",
                        HostId="8",
                        CollectionClearance=true,
                        MailAddress="elielhotel2020@gmail.com",
                        PhoneNumber="0546547645",
                        BankAccountNumber="456678951232",
                    }
                },
                new HostingUnit
                {Diary=BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = false,
                    ChildrensAttractions = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    Garden=false,
                  RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
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
                   },
                new HostingUnit
                {
                    Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Jerusalem,
                    Pool = true,
                    ChildrensAttractions = true,
                    FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = true,
                    Garden=true,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    HostingUnitName = "Ramada",
                    SubArea = "Ramot",
                    Jacuzz = true,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="Roni",
                        FamilyName="Yaniv",
                        HostId="9",
                        PhoneNumber="0589903450",
                        CollectionClearance=true,
                        MailAddress="RoniRamada@gmail.com",
                        BankAccountNumber="009821993432",
                    }
                   },
                new HostingUnit
                {
                Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    ChildrensAttractions = false,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    Garden=true,
                    HostingUnitName = "Yanir",
                    SubArea = "Netanya",
                    Jacuzz = false,
                    Type = UnitType.HostingUnit,
                    Owner= new Host
                    {
                        PrivateName="Yanir",
                        FamilyName="Roman",
                        HostId="10",
                        PhoneNumber="0549099095",
                        CollectionClearance=true,
                        MailAddress="yanirromanr@gmail.com",
                        BankAccountNumber="123421454432",
                    }
                   },
                new HostingUnit
                {
                Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Jerusalem,
                    Pool = true,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    ChildrensAttractions = true,
                     FreeParking=true,
                    breakfastIncluded=true,
                    AirConditoiner=true,
                    RoomService = true,
                    Garden=true,
                    HostingUnitName = "Mamila Hotel",
                    SubArea = "Mamila",
                    Jacuzz = true,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="Yoram",
                        FamilyName="Danon",
                        HostId="11",
                        PhoneNumber="0524454598",
                        CollectionClearance=true,
                        MailAddress="mamilahotel-yoram@gmail.com",
                        BankAccountNumber="009985346368",
                    }
                   },
                new HostingUnit
                {
                    Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = false,
                    ChildrensAttractions = true,
                     FreeParking=true,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    Garden=false,
                    HostingUnitName = "Nechama",
                    SubArea = "Ramat Gan",
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
                   },
                new HostingUnit
                {
                    Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = false,
                    ChildrensAttractions = false,
                    FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    Garden=false,
                     RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    HostingUnitName = "rami",
                    SubArea = "Beer Shave",
                    Jacuzz = false,
                    Type = UnitType.Tent,
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
                Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Garden = true,
                    Jacuzz =  true,
                    Pool = true,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    ChildrensAttractions = false,
                    AirConditoiner=true,
                    RoomService=false,
                    FreeParking=true,
                    breakfastIncluded=false,
                    HostingUnitName = "Clab Hotel",
                    SubArea = "Eilat",
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName ="Lieli",
                        FamilyName="Ob",
                        HostId="8",
                        CollectionClearance=true,
                        MailAddress="elielhotel2020@gmail.com",
                        PhoneNumber="0546547645",
                        BankAccountNumber="456678951232",
                    }
                   },
                new HostingUnit
                {Diary=BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = false,
                    ChildrensAttractions = true,
                    FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                     RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    Garden=false,
                    HostingUnitName = "Hotel metzada",
                    SubArea = "Metzada",
                    Jacuzz = false,
                    Type = UnitType.HotelRoom,
                    Owner= new Host
                    {
                        PrivateName="Lieli",
                        FamilyName="Ob",
                        HostId="8",
                        CollectionClearance=true,
                        MailAddress="elielhotel2020@gmail.com",
                        PhoneNumber="0546547645",
                        BankAccountNumber="456678951232",
                    }
                   },
                new HostingUnit
                {
                    Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = false,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    ChildrensAttractions = true,
                     FreeParking=true,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    Garden=false,
                    HostingUnitName = "Yonna",
                    SubArea = "Petach tikva",
                    Jacuzz = false,
                    Type = UnitType.HostingUnit,
                    Owner= new Host
                    {
                        PrivateName="Yonna",
                        FamilyName="Ariel",
                        HostId="12",
                        PhoneNumber="0533423450",
                        CollectionClearance=true,
                        MailAddress="petachtikvatYonna@gmail.com",
                        BankAccountNumber="009821454402",
                    }
                   },
                new HostingUnit
                {
                      Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.South,
                    Pool = false,
                    ChildrensAttractions = true,
                     FreeParking=true,
                     RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    breakfastIncluded=false,
                    AirConditoiner=true,
                    RoomService = false,
                    Garden=false,
                    HostingUnitName = "Ana tents",
                    SubArea = "Metzada",
                    Jacuzz = false,
                    Type = UnitType.Tent,
                    Owner= new Host
                    {
                        PrivateName="Anna",
                        FamilyName="Maxim",
                        HostId="13",
                        PhoneNumber="0555564450",
                        CollectionClearance=true,
                        MailAddress="anna123345@gmail.com",
                        BankAccountNumber="099082454432",
                    }
                   },
                new HostingUnit
                {
                        Diary =BE.Utils.createMatrix(),
                    HostingUnitKey = Configuration.HostingUnitId++,
                    Area = Areas.Center,
                    Pool = true,
                    ChildrensAttractions = true,
                     FreeParking=true,
                    breakfastIncluded=true,
                    AirConditoiner=true,
                    RoomService = true,
                    Garden=true,
                    RateAmount=150,
                amountOfRaters=70,
                     RateStars=150/70,
                    HostingUnitName = "Plaza2",
                    SubArea = "Tal Aviv",
                    Jacuzz = false,
                    Type = UnitType.HostingUnit,
                    Owner= new Host
                    {
                        PrivateName="Yarden",
                        FamilyName="Harari",
                        HostId="7",
                        PhoneNumber="0589823450",
                        CollectionClearance=true,
                        MailAddress="plazabyyardenr@gmail.com",
                        BankAccountNumber="123821454432",
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
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000008,
                    HostingUnitKey = 100000008,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000009,
                    HostingUnitKey = 100000009,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000010,
                    HostingUnitKey = 100000010,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000011,
                    HostingUnitKey = 100000011,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000012,
                    HostingUnitKey = 100000012,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000013,
                    HostingUnitKey = 100000013,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000014,
                    HostingUnitKey = 100000014,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000015,
                    HostingUnitKey = 100000015,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000016,
                    HostingUnitKey = 100000016,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000017,
                    HostingUnitKey = 100000017,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000018,
                    HostingUnitKey = 100000018,
                    Status = OrderStatus.SentMail
                },
                new Order
                {
                    OrderKey = Configuration.OrderId++,
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 100000019,
                    HostingUnitKey = 100000019,
                    Status = OrderStatus.SentMail
                },
            };

        }
    }
}