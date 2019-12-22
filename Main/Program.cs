using System;
using BE;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestRequest gr = new GuestRequest()
            {
                GuestRequestKey = Configuration.GuasteRequestId;
            Configuration.GuasteRequestId++;
            Console.WriteLine("Please enter your private name:");
            gr.PrivateName = Console.ReadLine();
            Console.WriteLine("Please enter your family name:");
            gr.FamilyName = Console.ReadLine();
            Console.WriteLine("Please enter your E-mail:");
            gr.MailAddress = Console.ReadLine();
            gr.RegistrationDate = DateTime.Now.Date;
            gr.Status = "Active";
            bool success = false;
            bool success2 = false;
            while (!success)
            {
                Console.WriteLine("please enter the date you want to reserve.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                try
                {
                    string date = Console.ReadLine();
                    gr.EntryDate = DateTime.Parse(date);
                    success = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" sorry, invalid input, please try again. ");
                    Console.ResetColor();
                    success = false;

                }
            }
            while (!success2)
            {
                Console.WriteLine("please enter the date you want to leave.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                try
                {
                    string date = Console.ReadLine();
                    gr.ReleaseDate = DateTime.Parse(date);
                    success2 = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" sorry, invalid input, please try again. ");
                    Console.ResetColor();
                    success2 = false;

                }
            }
            Console.WriteLine("Please choose an area you want to stay at:");
            Console.WriteLine("1- for south");
            Console.WriteLine("2- for north");
            Console.WriteLine("3- for center");
            Console.WriteLine("4- for jerusalem");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    gr.Area = Areas.South;
                    break;
                case "2":
                    gr.Area = Areas.North;
                    break;
                case "3":
                    gr.Area = Areas.Center;
                    break;
                case "4":
                    gr.Area = Areas.Jerusalem;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Please enter a sub area in the area u have chosen:");
            gr.SubArea = Console.ReadLine();
            Console.WriteLine("Please choose the type of hosting unit you want to stay at:");
            Console.WriteLine("1- for  Tzimer");
            Console.WriteLine("2- for HostingUnit");
            Console.WriteLine("3- for HotelRoom");
            Console.WriteLine("4- for  Tent");
            string typeAnswer = Console.ReadLine();
            switch (typeAnswer)
            {
                case "1":
                    gr.Type = UnitType.Tzimer;
                    break;
                case "2":
                    gr.Type = UnitType.HostingUnit;
                    break;
                case "3":
                    gr.Type = UnitType.HotelRoom;
                    break;
                case "4":
                    gr.Type = UnitType.Tent;
                    break;
                default:
                    break;

            }
            Console.WriteLine("Please enter the number of adults :");
            gr.Adults = Console.ReadLine();
            Console.WriteLine("Please enter the number of children :");
            gr.Children = Console.ReadLine();
            Console.WriteLine(" Do you want a pool?");
            Console.WriteLine("1- neccesery");
            Console.WriteLine("2- possible");
            Console.WriteLine("3- notinterstid");
            string poolanswer = Console.ReadLine();
            switch (poolanswer)
            {
                case "1":
                    gr.Pool = hotelAdditions.neccesery;
                    break;
                case "2":
                    gr.Pool = hotelAdditions.possible;
                    break;
                case "3":
                    gr.Pool = hotelAdditions.notintersted;
                    break;
            }
            Console.WriteLine(" Do you want a jaccuz?");
            Console.WriteLine("1- neccesery");
            Console.WriteLine("2- possible");
            Console.WriteLine("3- notinterstid");
            string jaccuzAnswer = Console.ReadLine();
            switch (jaccuzAnswer)
            {
                case "1":
                    gr.Jacuzz = hotelAdditions.neccesery;
                    break;
                case "2":
                    gr.Jacuzz = hotelAdditions.possible;
                    break;
                case "3":
                    gr.Jacuzz = hotelAdditions.notintersted;
                    break;
            }
            Console.WriteLine(" Do you want a garden?");
            Console.WriteLine("1- neccesery");
            Console.WriteLine("2- possible");
            Console.WriteLine("3- notinterstid");
            string gardenAnswer = Console.ReadLine();
            switch (gardenAnswer)
            {
                case "1":
                    gr.Garden = hotelAdditions.neccesery;
                    break;
                case "2":
                    gr.Garden = hotelAdditions.possible;
                    break;
                case "3":
                    gr.Garden = hotelAdditions.notintersted;
                    break;
            }
            Console.WriteLine(" Do you want  ChildrensAttractions? :");
            Console.WriteLine("1- neccesery");
            Console.WriteLine("2- possible");
            Console.WriteLine("3- notinterstid");
            string ChildrensAttractionsanswer = Console.ReadLine();
            switch (ChildrensAttractionsanswer)
            {
                case "1":
                    gr.ChildrensAttractions = hotelAdditions.neccesery;
                    break;
                case "2":
                    gr.ChildrensAttractions = hotelAdditions.possible;
                    break;
                case "3":
                    gr.ChildrensAttractions = hotelAdditions.notintersted;
                    break;
            }
            // } סןגר של מחלקת geustRequest

            HostingUnit hu = new HostingUnit()
            {
                hu.GuestRequestKey = Configuration.HostingUnitId;
            Configuration.HostingUnitId++;
            hu.Diary = new bool[12, 31];// Matrix of hotel capacity.
            hu.FillMatrix(hu.Diary);
            Console.WriteLine("Please enter the units name: ");
            hu.HostingUnitName = Console.ReadLine();
            Console.WriteLine("Please choose an area you want to locate your hosting unit:");
            Console.WriteLine("1- for south");
            Console.WriteLine("2- for north");
            Console.WriteLine("3- for center");
            Console.WriteLine("4- for jerusalem");
            string areaAnswer1 = Console.ReadLine();
            switch (areaAnswer1)
            {
                case "1":
                    hu.Area = Areas.South;
                    break;
                case "2":
                    hu.Area = Areas.North;
                    break;
                case "3":
                    hu.Area = Areas.Center;
                    break;
                case "4":
                    hu.Area = Areas.Jerusalem;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Please enter a sub area for your hosting unit:");
            gr.SubArea = Console.ReadLine();
            Console.WriteLine("Please choose the type of unit you want to build:");
            Console.WriteLine("1- for Tzimer");
            Console.WriteLine("2- for HostingUnit");
            Console.WriteLine("3- for HotelRoom");
            Console.WriteLine("4- for Tent");
            string typeAnswer1 = Console.ReadLine();
            switch (typeAnswer1)
            {
                case "1":
                    hu.Type = UnitType.Tzimer;
                    break;
                case "2":
                    hu.Type = UnitType.HostingUnit;
                    break;
                case "3":
                    hu.Type = UnitType.HotelRoom;
                    break;
                case "4":
                    hu.Type = UnitType.Tent;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Do you have a pool? Please answer 1 if so, and 0 if not. ");
            string poolGardenAttracyionslAnswer = Console.ReadLine();
            if (poolGardenAttracyionslAnswer == "0")
            {
                hu.Pool = false;
            }
            else
            {
                hu.Pool = true;
            }
            Console.WriteLine("Do you have a jaccuz? Please answer 1 if so, and 0 if not. ");
            poolGardenAttracyionslAnswer = Console.ReadLine();
            if (poolGardenAttracyionslAnswer == "0")
            {
                hu.Jacuzz = false;
            }
            else
            {
                hu.Jacuzz = true;
            }
            Console.WriteLine("Do you have a garden? Please answer 1 if so, and 0 if not. ");
            poolGardenAttracyionslAnswer = Console.ReadLine();
            if (poolGardenAttracyionslAnswer == "0")
            {
                hu.Garden = false;
            }
            else
            {
                hu.Garden = true;
            }
            Console.WriteLine("Do you have a ChildrensAttractions ? Please answer 1 if so, and 0 if not. ");
            poolGardenAttracyionslAnswer = Console.ReadLine();
            if (poolGardenAttracyionslAnswer == "0")
            {
                hu.ChildrensAttractions = false;
            }
            else
            {
                hu.ChildrensAttractions = true;
            }
      //  } אמור להיות הסוגר של האיתחול של hostingUnit
            Host H = new Host()
            {
                Console.WriteLine("please enter your ID");
            string answer5 = Console.ReadLine();
            H.HostKey = int.Parse(answer5);
            Console.WriteLine("Please enter your private name:");
            H.PrivateName = Console.ReadLine();
            Console.WriteLine("Please enter your family name:");
            H.FamilyName = Console.ReadLine();
            Console.WriteLine("Please enter your E-mail:");
            H.MailAddress = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");
            gr.MailAddress = Console.ReadLine();

            BankBranch bb = new BankBranch()
            {
                Console.WriteLine(" Please enter your bank number:");
            bb.BankName = Console.ReadLine();
            Console.WriteLine("Please enter your bank name:");
            bb.BankName = Console.ReadLine();
            Console.WriteLine("Please enter your branch number");
            bb.BranchNumber = Console.ReadLine();
            Console.WriteLine("Please enter your branch address:");
            bb.BranchAddress = Console.ReadLine();
            Console.WriteLine("Please enter yout branch city:");
            bb.BranchCity = Console.ReadLine();

            Order o = new Order()
            { Console.WriteLine("Please eter yout guest request key:");
                o.GuestRequestKey =int.Parse( Console.ReadLine());
            Console.WriteLine("Please enter your order key: ");
            o.OrderKey = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your status: ");
            Console.WriteLine("1- for a not handled case.");
            Console.WriteLine("2- for a sent mail case.");
            Console.WriteLine("3- for closed request.");
            Console.WriteLine("4- for confirmed closed request.");
            string orderAnswer1 = Console.ReadLine();
            switch (orderAnswer1)
            {
                case "1":
                    o.Status = OrderStatus.NotHandled;
                    break;
                case "2":
                    o.Status = OrderStatus.SentMail;
                    break;
                case "3":
                    o.Status = OrderStatus.ClosedRequest;
                    break;
                case "4":
                    o.Status = OrderStatus.ConfirmedClosedRequest;
                    break;
                default:
                    break;
            }
            //} סוגר של איתחול ההזמנה Order
            Console.WriteLine("Please enter your create date: ");
            o.CreateDate = DateTime.Now;
            Console.WriteLine("Please enter your order date: ");
            
        }
    }
}