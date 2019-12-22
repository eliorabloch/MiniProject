using DAL;
using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class MyBL : IBL
    {
        #region Singleton
        private static readonly MyBL instance = new MyBL();

        public static MyBL Instance
        {
            get { return instance; }
        }
        #endregion

        static IDAL myDAL;

        static MyBL()
        {
            string TypeDAL = ConfigurationSettings.AppSettings.Get("TypeDS");
            //string TypeDAL = "List";
            myDAL = factoryDAL.getDAL(TypeDAL);
        }
        public void InvalidDate(GuestRequest gr)//פונקציה שבודקת האם יום הכניסה קודם ליום היציאה
        {

            // if (!(((gr.EntryDate.Day < gr.ReleaseDate.Day) && (gr.EntryDate.Month == gr.ReleaseDate.Month)) || (gr.EntryDate.Month < gr.ReleaseDate.Month)))
            if (gr.EntryDate < gr.ReleaseDate)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Sorry, invalid date, please try again. ");
                Console.ResetColor();
                Console.WriteLine("Please enter the date you want to reserve.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                Console.WriteLine();
                Console.WriteLine("please enter the date you want to leave.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                Console.WriteLine();


            }


        }
        List<HostingUnit> availableUnit(List<HostingUnit> getUnitList, DateTime date, int amount)
        {

            List<HostingUnit> mylist = new List<HostingUnit>;
            foreach (var item in getUnitList)
            {
                if (availableDate(item, date, amount))
                {
                    mylist.Add(item);
                }
            }
            return mylist;


        }
        void sendOrder(Host h, Order o)//
        {
            if (h.CollectionClearance)
            {
                o.Status = OrderStatus.SentMail;
            }

        }
        bool availableDate(HostingUnit H, DateTime d, int amount)
        {
            DateTime release = d.AddDays(amount);
            while (d < release)
            {
                if (H.Diary[d.Month - 1, d.Day - 1])
                {
                    return false;
                }
                d = d.AddDays(1);
            }
            return true;
        }


        bool availableDate(HostingUnit H, GuestRequest G)
        {
            DateTime temp = G.EntryDate;
            while (temp < G.ReleaseDate)
            {
                if (H.Diary[temp.Month - 1, temp.Day - 1])
                {
                    return false;
                }
                temp = temp.AddDays(1);
            }
            return true;
        }
        int amountOfDays(DateTime D1, DateTime D2)
        {
            int amount = 0;
            if (D1.Month == D2.Month)
            { amount = D2.Day - D1.Day; }
            else amount = (D2.Day - D1.Day) + 31;

            return amount;
        }
        List<Order> howManyOrders(int amountOfDays, List<Order> orderList)
        {
            List<Order> myList = new List<Order>();
            myList = null;
            int amount = 0;
            int monthAmount = 0;

            foreach (var item in orderList)
            {
                if (item.CreateDate.Month == DateTime.Now.Month)
                {
                    amount = (DateTime.Now.Day - item.CreateDate.Day);

                    if (amount >= amountOfDays)
                        myList.Add(item);
                }
                else
                {
                    monthAmount = DateTime.Now.Month - item.CreateDate.Month;
                    amount = 31 * monthAmount + DateTime.Now.Day - item.CreateDate.Day;
                    if (amount >= amountOfDays)
                        myList.Add(item);
                }
            }

            return myList;

        }
        int amountOfOrders(HostingUnit h,List<Order> orderList)
        {
            int sum = 0;
            foreach(var item in orderList)
            {
                if(item.HostingUnitKey==h.HostingUnitKey)
                {
                    if (item.Status== OrderStatus.ClosedRequest|| item.Status == OrderStatus.ConfirmedClosedRequest)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }



    }

}


   

