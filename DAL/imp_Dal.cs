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

        #region Guest Requst

        public List<GuestRequest> GetGuestRequestList()//מחזיר רשימת בקשות אירוח
        {
            return (from gr in DataSource.requestList
                   select (GuestRequest)gr.Clone()).ToList();
        }

        public GuestRequest GetRequest(int id)
        {
            return (GuestRequest)GetGuestRequestList().FirstOrDefault(x=>x.GuestRequestKey == id).Clone();
        }

        public void AddRequest(GuestRequest newRequest)//מוסיף דרישת אירוח חדשה
        {
            if(GetGuestRequestList().Any(x => x.GuestRequestKey == newRequest.GuestRequestKey))
            {
                throw new TzimerException($"Guest Request with the ID: {newRequest.GuestRequestKey} - already exists!", "dal");
            }
            DataSource.requestList.Add((GuestRequest)newRequest.Clone());
        }

        public void UpdateRequest(GuestRequest updatedRequest)//פונקציה שמשנה את הסטטוס של הבקשה- פעילה או לא
        {
            DataSource.requestList = (from x in GetGuestRequestList()
                                   let Status = updatedRequest.Status
                                   where x.GuestRequestKey == updatedRequest.GuestRequestKey
                                   select (GuestRequest)x.Clone()).ToList();
        }

        public void DeleteRequest(GuestRequest newRequest)
        {
            GetGuestRequestList().RemoveAll(x => x.GuestRequestKey == newRequest.GuestRequestKey);
        }

        #endregion

        #region Hosting Units

        public List<HostingUnit> GetUnitsList()//מחזיר רשימת אירוח
        {
            return (from gr in DataSource.unitList
                    select (HostingUnit)gr.Clone()).ToList();
        }

        public HostingUnit GetUnit(int id)
        {
            return (HostingUnit)DataSource.unitList.FirstOrDefault(x => x.HostingUnitKey == id).Clone();
        }

        public void AddUnit(HostingUnit newUnit)//הוספת יחידית אירוח
        {
            if (GetUnitsList().Any(x => x.HostingUnitKey == newUnit.HostingUnitKey))
            {
                throw new TzimerException($"Hosting Unit with the ID: {newUnit.HostingUnitKey} - already exists!", "dal");
            }
            DataSource.unitList.Add((HostingUnit)newUnit.Clone());
        }

        public void UpdateUnit(HostingUnit updatedUnit)
        {
            DataSource.unitList = DataSource.unitList
               .Select(x => {
                   if(x.HostingUnitKey == updatedUnit.HostingUnitKey)
                   {
                       x = updatedUnit;
                   }
                    return (HostingUnit)x.Clone();
               })
               .ToList();
        }

        public void DeleteUnit(HostingUnit delUnit)//מוחק את כל היחידה
        {
            GetUnitsList().RemoveAll(x => x.HostingUnitKey == delUnit.HostingUnitKey);
        }
        #endregion

        #region Orders

        public List<Order> GetOrdersList()//מחזיר רשימת הזמנות
        {
            return (from d in DataSource.orderList
                    select (Order)d.Clone()).ToList();
        }

        public Order GetOrder(int id)
        {
            return (Order)DataSource.orderList.FirstOrDefault(x => x.OrderKey == id).Clone();
        }

        public void AddOrder(Order newOrder)//מוסיף הזמנה לרשימה
        {
            if (GetOrdersList().Any(x => x.OrderKey == newOrder.OrderKey))
            {
                throw new TzimerException($"Order with the ID: {newOrder.OrderKey} - already exists!", "dal");
            }
            DataSource.orderList.Add((Order)newOrder.Clone());
        }

        public void UpdateOrder(Order updatedOrder)//פונקציה שמעדכנת את הסטטוס של ההזמנה לפי מה שהמארח יחליט לשנות
        {
            DataSource.orderList = (from order in GetOrdersList()
                                   let Status = updatedOrder.Status
                                    where order.OrderKey == updatedOrder.OrderKey 
                                   select (Order)order.Clone()).ToList();
        }


        public void DeleteOrder(Order order)
        {
            DataSource.orderList.RemoveAll(x => x.OrderKey == order.OrderKey);
        }

        #endregion

        public List<BankBranch> GetBankList()// מחזיר מתוך רשימה של חשבונות בנקים רק את שמות הבנקים על ידי שימוש בlinq 
        {
            return new List<BankBranch>
            {
                new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                },
                 new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                },
                  new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                },
                   new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                },
                    new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                }
            };
        }



    

       
    }
}