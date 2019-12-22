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
            Console.WriteLine("please choose an area you want to stay at:");
            Console.WriteLine("1 for south");
            Console.WriteLine("2 for north");
            Console.WriteLine("3 for center");
            Console.WriteLine("4 for jerusalem");
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
            Console.WriteLine("please enter a sub area in the area u have chosen:");
            gr.SubArea = Console.ReadLine();
            Console.WriteLine("please choose the type of hosting unit you want to stay at:");
            Console.WriteLine("1 for  Tzimer");
            Console.WriteLine("2 for HostingUnit");
            Console.WriteLine("3 for HotelRoom");
            Console.WriteLine("4 for  Tent");
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
            Console.WriteLine(" Do you want a pool? :");
            Console.WriteLine("1-neccesery");
            Console.WriteLine("2-possible");
            Console.WriteLine("3-notinterstid");
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
            Console.WriteLine(" Do you want a jaccuz? :");
            Console.WriteLine("1-neccesery");
            Console.WriteLine("2-possible");
            Console.WriteLine("3-notinterstid");
            string jaccuzanswer = Console.ReadLine();
            switch (jaccuzanswer)
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

            Console.WriteLine(" Do you want a garden? :");
            Console.WriteLine("1-neccesery");
            Console.WriteLine("2-possible");
            Console.WriteLine("3-notinterstid");
            string gardenanswer = Console.ReadLine();
            switch (gardenanswer)
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
            Console.WriteLine("1-neccesery");
            Console.WriteLine("2-possible");
            Console.WriteLine("3-notinterstid");
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


            HostingUnit hu = new HostingUnit()
            {
                hu.GuestRequestKey = Configuration.HostingUnitId;
            Configuration.HostingUnitId++;


            hu.Diary = new bool[12, 31];// Matrix of hotel capacity.
            hu.FillMatrix(hu.Diary);

            Console.WriteLine("please enter the units name: ");
            hu.HostingUnitName = Console.ReadLine();
            Console.WriteLine("please choose an area you want to locate your hosting unit:");
            Console.WriteLine("1 for south");
            Console.WriteLine("2 for north");
            Console.WriteLine("3 for center");
            Console.WriteLine("4 for jerusalem");
            string answer1 = Console.ReadLine();


            switch (answer1)
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
            Console.WriteLine("please enter a sub area for your hosting unit:");
            gr.SubArea = Console.ReadLine();
            Console.WriteLine("please choose the type of unit you want to build:");
            Console.WriteLine("1 for  Tzimer");
            Console.WriteLine("2 for HostingUnit");
            Console.WriteLine("3 for HotelRoom");
            Console.WriteLine("4 for  Tent");
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

            Console.WriteLine(" do you have a pool? please answer 1 if so, and 0 if not ");
            string answer3 = Console.ReadLine();
            if (answer3 == "0")

                hu.Pool = false;
            else hu.Pool = true;

            Console.WriteLine(" do you have a jaccuz? please answer 1 if so, and 0 if not ");
            answer3 = Console.ReadLine();
            if (answer3 == "0")

            { hu.Jacuzz = false; }
            else { hu.Jacuzz = true; }

            Console.WriteLine(" do you have a garden? please answer 1 if so, and 0 if not ");
            answer3 = Console.ReadLine();
            if (answer3 == "0")

            { hu.Garden = false;
            }
            else { hu.Garden = true; }

            Console.WriteLine(" do you have a ChildrensAttractions ? please answer 1 if so, and 0 if not ");
            answer3 = Console.ReadLine();
            if (answer3 == "0")

            {
                hu.ChildrensAttractions = false;
            }
            else { hu.ChildrensAttractions = true; }


            Host ahost = new Host()
            {
                Console.WriteLine("please enter your id");
            string answer5 = Console.ReadLine();
            ahost.HostKey = int.Parse(answer5);
            Console.WriteLine("Please enter your private name:");
            ahost.PrivateName = Console.ReadLine();
            Console.WriteLine("Please enter your family name:");
            ahost.FamilyName = Console.ReadLine();
            Console.WriteLine("Please enter your E-mail:");
            ahost.MailAddress = Console.ReadLine();
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
        }

    }



    }

}

    }
    
    

     
         





    }



    }
       
    

       























