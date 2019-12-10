using BE;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class imp_Dal:IDAL 
    {
        public void addRequest(GuestRequest newRequest)//מוסיף דרישת אירוח חדשה
        {
            DataSource.requestList.Add(newRequest);
        }
        public void updateRequest(GuestRequest update)
        {
           
        }
        public void updateUnit(HostingUnit update)
        {

        }
        public void updateOrder(Order update)
        {

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

        public void deleteUnit(HostingUnit delUnit)
        {
            getUnitsList().RemoveAll(x => x.HostingUnitKey == delUnit.HostingUnitKey);
        }

        public List<string> getBankList(List<BankAccount> bankLists)// מחזיר מתוך רשימה של חשבונות בנקים רק את שמות הבנקים על ידי שימוש בlinq 
        {
           var newBankLists = bankLists.Select(x=>x.BankName).ToList();
           return newBankLists;
        }
    }


}
