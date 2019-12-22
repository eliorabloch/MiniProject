using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        void addRequest(GuestRequest newRequest);//מוסיף דרישת אירוח חדשה
        void updateRequest(GuestRequest update);
        void addUnit(HostingUnit newUnit);//הוספת יחידת אירוח
        void deleteUnit(HostingUnit delUnit);
        void updateUnit(HostingUnit update);
        void addOrder(Order newOrder);//מוסיף הזמנה לרשימה
        void updateOrder(Order update);
        List<HostingUnit> getUnitsList ();// מחזיר רשימת אירוח
        List<GuestRequest> getCustomersList ();// מחזיר רשימת בקשות אירוח
        List<Order> getOrdersList();//מחזיר רשימת הזמנות
        List <string> getBankList(List <BankBranch> bankLists);
    }
}
