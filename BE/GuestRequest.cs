using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {
         public int GuestRequestKey { get; set; }
        string PrivateName { get; set; }
        string FamilyName { get; set; }
        string MailAddress { get; set; }
        string Status { get; set; }
        DateTime RegistrationDate { get; set; }
        DateTime EntryDate { get; set; }
        DateTime ReleaseDate { get; set; }
        string Area { get; set; }
        string SubArea { get; set; }
        string Type { get; set; }
        int Adults { get; set; }
        int Children { get; set; }
        string Pool { get; set; }
        string Jacuzz { get; set; }
        string Garden { get; set; }
        string ChildrensAttractions { get; set; }
         public string toString { get; set; }

        //functions
        public GuestRequest()//Regular constractor.
        {
            bool success = false;
            bool success2 = false;
            while (!success)
            {
                Console.WriteLine("please enter the date you want to reserve.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                try
                {
                    string date = Console.ReadLine();
                    EntryDate = DateTime.Parse(date);
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
                    ReleaseDate = DateTime.Parse(date);
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
        }

        public GuestRequest(bool flagEntryDate)//Constractor for a random guest.
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            string dateAsString = getRandomDateString();
            DateTime dateOut;
            while (!DateTime.TryParse(dateAsString, out dateOut))//Try to turn the string into a daytime parameter.
            {
                dateAsString = getRandomDateString();//If the date doesnt exist, we get a new random date.
            }
            EntryDate = dateOut;
            ReleaseDate = EntryDate.AddDays(rand.Next(2, 10));//Add days,and gives us the release date.
        }

        private string getRandomDateString()//Funcion that creates the random guest request.
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int randBeginMonth = rand.Next(1, 12);//Random month.
            int randBeginDay = rand.Next(1, 31);//Random day.
            string leaveDate = (string)(randBeginDay + "-" + randBeginMonth);
            return leaveDate;//Returns the string with the new random date.
        }

        public override string ToString()
        {
            toString = "";
            toString += "this is your request information: \n";
            toString
                += $"entry date: {EntryDate} \n";
            toString += $"Realese date: {ReleaseDate} \n";
            return toString;


        }
    }
    }
}
