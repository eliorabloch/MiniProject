using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class imp_Dal:IDAL 
    {
        bool[,] capacity;
        public void addRequest(GuestRequest newRequest)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the date you want to reserve.");
            Console.WriteLine("Day: ");
            //We will cin a key by the customer (on day, month, amount). We will parse it into an int, and we will also check that the numbers are in the corrent range.
            string costumerDay = Console.ReadLine();
            int day, day2;
            bool succeedDay = int.TryParse(costumerDay, out day);//We check if the parsing went well.
            bool succeedDay2 = true;
            day -= 1;// We will remove 1 from the day number,because the array starts from 0.
            if (succeedDay)
            {
                while ((day > 30 || day < 0) && (succeedDay2))//We check that the day is in the range.
                {
                    Console.WriteLine("You have entered an invalid day, please enter a correct number.");
                    string costumerDay2 = Console.ReadLine();
                    succeedDay2 = int.TryParse(costumerDay2, out day2);
                    day = day2;
                    day -= 1;
                }
            }
            else
            {
                Console.WriteLine("Sorry, we can not handle this problem.");//This is incase the custumor entered somthing other then a number.
                return;
            }
            //Here we do for the month the exact things we did for the day.
            Console.WriteLine("Month: ");
            string costumerMonth = Console.ReadLine();
            int month, month2;
            bool succeedMonth = int.TryParse(costumerMonth, out month);
            bool succeedMonth2 = true;
            month -= 1;
            if (succeedMonth)
            {
                while ((month > 11 || month < 0) && (succeedMonth2))
                {
                    Console.WriteLine("You have entered an invalid day, please enter a correct number.");
                    string costumerMonth2 = Console.ReadLine();
                    succeedMonth2 = int.TryParse(costumerMonth2, out month2);
                    month = month2;
                    month -= 1;
                }
            }
            else
            {
                Console.WriteLine("Sorry, we can not handle this problem.");
                return;
            }
            Console.WriteLine("Please enter the amount of days for your stay.");
            string amountOfDays = Console.ReadLine();
            int amount;
            bool succeedAmount = int.TryParse(amountOfDays, out amount);
            if (!succeedAmount)
            {
                Console.WriteLine("Sorry, we can not handle this problem.");
                return;
            }
            int saveAmount = amount;
            int newAmount = 0;
            int newMonth = 0;
            if (day + amount > 30)//Here we check if we have on order that takes place in two monthes or more.
            {
                amount = 31 - day;//Accurate month
                newAmount = saveAmount - amount;//Next month
                newMonth = month + 1;
            }
            bool available = false;
            int forSum = 0;
            if (!capacity[month, day])// If the room ia availeble we will enter the for.
            {
                for (int i = 0; i < amount - 1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                {
                    if (capacity[month, day + i])
                    {
                        Console.WriteLine("Sorry, the request has been denighd.");
                        forSum = i;
                        break;
                    }
                }
                if (forSum == amount - 2 || forSum == 0)// If none of the days were taken (not including the first and the last), we will update the available flag to be true. 
                {
                    available = true;
                }
            }
            else
            {
                Console.WriteLine("Sorry, the request has been denighd.");
            }
            bool available2 = false;
            if (available)
            {
                for (int i = 0; i < newAmount - 1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                {
                    if (capacity[newMonth, day + i])
                    {
                        Console.WriteLine("Sorry, the request has been denighd.");
                        forSum = i;
                        break;
                    }
                }
                if (forSum == amount - 2 || forSum == 0)// If none of the days were taken (not including the first and the last), we will update the available flag to be true. 
                {
                    available2 = true;
                }
            }
            //We will go in to this if incase we have an order of more then one month.
            if (available && available2)// This is where we update the capacity.
            {
                for (int i = 0; i < amount; i++)
                {
                    capacity[month, day + i] = true;
                }
                for (int i = 1; i < newAmount + 1; i++)
                {
                    capacity[newMonth, i] = true;
                }
                Console.WriteLine("The request has been answerred");
            }
            if (newMonth == 0)// If its only one month.
            {
                for (int i = 0; i < amount; i++)
                {
                    capacity[month, day + i] = true;
                }
            }
            //if ((day == 30) && (month == 12) && (amount > 1))
            //{
            //    Console.WriteLine("Sorry, we can not get yout resservation.");
            //    Console.WriteLine("See you next year!");
            //}
        }
        public void updateRequest(GuestRequest update)
        {

        }
    }


}
