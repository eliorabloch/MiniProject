using System;
using BE;
using BL;
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
            Console.WriteLine("Please enter your E-mail address:");
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
            Console.WriteLine("Please enter a sub area in the area you have chosen:");
            gr.SubArea = Console.ReadLine();
            Console.WriteLine("Please choose the type of hosting unit you want to stay at:");
            Console.WriteLine("1- for tzimer");
            Console.WriteLine("2- for hosting unit");
            Console.WriteLine("3- for hotel room");
            Console.WriteLine("4- for tent");
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
            Console.WriteLine("Please enter the number of adults you are:");
            gr.Adults = Console.ReadLine();
            Console.WriteLine("Please enter the number of children you have:");
            gr.Children = Console.ReadLine();
            Console.WriteLine(" Do you want a pool?");
            Console.WriteLine("1- neccesery");
            Console.WriteLine("2- possible");
            Console.WriteLine("3- not intersted");
            string poolanswer = Console.ReadLine();
            switch (poolanswer)
            {
                case "1":
                    gr.Pool = Options.neccesery;
                    break;
                case "2":
                    gr.Pool = Options.possible;
                    break;
                case "3":
                    gr.Pool = Options.notintersted;
                    break;
            }
            Console.WriteLine(" Do you want a jaccuz?");
            Console.WriteLine("1- neccesery");
            Console.WriteLine("2- possible");
            Console.WriteLine("3- not intersted");
            string jaccuzAnswer = Console.ReadLine();
            switch (jaccuzAnswer)
            {
                case "1":
                    gr.Jacuzz = Options.neccesery;
                    break;
                case "2":
                    gr.Jacuzz = Options.possible;
                    break;
                case "3":
                    gr.Jacuzz = Options.notintersted;
                    break;
            }
            Console.WriteLine(" Do you want a garden?");
            Console.WriteLine("1- neccesery");
            Console.WriteLine("2- possible");
            Console.WriteLine("3- not intersted");
            string gardenAnswer = Console.ReadLine();
            switch (gardenAnswer)
            {
                case "1":
                    gr.Garden = Options.neccesery;
                    break;
                case "2":
                    gr.Garden = Options.possible;
                    break;
                case "3":
                    gr.Garden = Options.notintersted;
                    break;
            }
            Console.WriteLine(" Do you want a attractions for childrens?:");
            Console.WriteLine("1- neccesery");
            Console.WriteLine("2- possible");
            Console.WriteLine("3- not intersted");
            string ChildrensAttractionsanswer = Console.ReadLine();
            switch (ChildrensAttractionsanswer)
            {
                case "1":
                    gr.ChildrensAttractions = Options.neccesery;
                    break;
                case "2":
                    gr.ChildrensAttractions = Options.possible;
                    break;
                case "3":
                    gr.ChildrensAttractions = Options.notintersted;
                    break;
            }
            // } סןגר של מחלקת geustRequest

            HostingUnit hu = new HostingUnit()
            {
                hu.HostingUnitKey = Configuration.HostingUnitId;
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
            Console.WriteLine("1- for tzimer");
            Console.WriteLine("2- for hosting unit");
            Console.WriteLine("3- for hotel room");
            Console.WriteLine("4- for tent");
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
            Console.WriteLine("Do you have an attractions for childrens ? Please answer 1 if so, and 0 if not. ");
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
            string idAnswer = Console.ReadLine();
            H.HostKey = int.Parse(idAnswer);
            Console.WriteLine("Please enter your private name:");
            H.PrivateName = Console.ReadLine();
            Console.WriteLine("Please enter your family name:");
            H.FamilyName = Console.ReadLine();
            Console.WriteLine("Please enter your E-mail:");
            H.MailAddress = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");
            gr.MailAddress = Console.ReadLine();
            //}סוגר איתחול של host

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
            {
                Console.WriteLine("Please eter yout hosting unit key:");
            o.HostingUnitKey = int.Parse(Console.ReadLine());
            Console.WriteLine("Please eter yout guest request key:");
            o.GuestRequestKey = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your order key: ");
            o.OrderKey = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your status: ");
            Console.WriteLine("1- for a not handled case.");
            Console.WriteLine("2- for a sent mail case.");
            Console.WriteLine("3- for closed request.");
            Console.WriteLine("4- for confirmed closed request.");
            string orderAnswer = Console.ReadLine();
            switch (orderAnswer)
            {
                case "1":
                    o.Status = OrderStatus.NotHandled;
                    break;
                case "2":
                    o.Status = OrderStatus.SentMail;
                    break;
                case "3":
                    o.Status = OrderStatus.ClosedRequestCanceled;
                    break;
                case "4":
                    o.Status = OrderStatus.ClosedRequestDoneDeal;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Please enter your create date: ");
            o.CreateDate = DateTime.Now;
            Console.WriteLine("Please enter your order date: ");
            if (sendOrder(H, o))
            {
                o.OrderDate= 
            }
            //} סוגר של איתחול order
        }
    }
}