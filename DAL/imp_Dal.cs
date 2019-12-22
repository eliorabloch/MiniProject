using BE;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class imp_Dal : IDAL
    {
        // סינגלטון
        private static imp_Dal instance = null;//שדה שבו נגדיר את המופע הראשון שלנו
        public static imp_Dal getInstance()//פונקציה סטטית שדואגת לייצר את המופע שלנו פעם אחת בלבד.
        {
            if (instance == null)
            {
                instance = new imp_Dal();
            }
            return instance;
        }
        private imp_Dal() { }//constractor
        public void addRequest(GuestRequest newRequest)//מוסיף דרישת אירוח חדשה
        {
            DataSource.requestList.Add(newRequest);
        }
        public void updateRequest(GuestRequest update)//פונקציה שמשנה את הסטטוס של הבקשה- פעילה או לא
        {
            
            Console.WriteLine("Please choose a new status to your order:");
            if (update.Status == "active")
            {
                update.Status = "NotActive";
            }
            update.Status = "active";
        }
        public void updateUnit(Host h, HostingUnit update)
        {
            h.FamilyName = "liel";
        }
        public void updateOrder(Order update)//פונקציה שמעדכנת את הסטטוס של ההזמנה לפי מה שהמארח יחליט לשנות
        {
            Console.WriteLine("Please choose a new status to your order:");
            Console.WriteLine("1- for not handled order.");
            Console.WriteLine("2- for a sent mail case. ");
            Console.WriteLine("3- if the order is closed.");
            Console.WriteLine("4- if the order us confirmed and closed.");
            Console.WriteLine();
            string orderAnswer = Console.ReadLine();
            switch (orderAnswer)
            {
                case "1":
                    update.Status = OrderStatus.NotHandled;
                    break;

                case "2":
                    update.Status = OrderStatus.SentMail;
                    break;

                case "3":
                    update.Status = OrderStatus.ClosedRequest;
                    break;

                case "4":
                    update.Status = OrderStatus.ConfirmedClosedRequest;
                    break;

                default:
                    break;

            }
        }
        public List<HostingUnit> getUnitsList()//מחזיר רשימת אירוח
        {
            return DataSource.unitList;
        }
        public List<GuestRequest> getCustomersList()//מחזיר רשימת בקשות אירוח
        {
            return DataSource.requestList;
        }
        public List<Order> getOrdersList()//מחזיר רשימת הזמנות
        {
            return DataSource.orderList;
        }
        public void addUnit(HostingUnit newUnit)//הוספת יחידית אירוח
        {
            DataSource.unitList.Add(newUnit);
        }
        public void addOrder(Order newOrder)//מוסיף הזמנה לרשימה
        {
            DataSource.orderList.Add(newOrder);
        }
        public void deleteUnit(HostingUnit delUnit)//מוחק את כל היחידה
        {
            getUnitsList().RemoveAll(x => x.HostingUnitKey == delUnit.HostingUnitKey);
        }
        public List<string> getBankList(List<BankBranch> bankLists)// מחזיר מתוך רשימה של חשבונות בנקים רק את שמות הבנקים על ידי שימוש בlinq 
        {
            var newBankLists = bankLists.Select(x => x.BankName).ToList();
            return newBankLists;
        }
    }
}