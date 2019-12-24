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
        GuestRequest GetRequest(int id);
        void AddRequest(GuestRequest newRequest);//מוסיף דרישת אירוח חדשה
        void UpdateRequest(GuestRequest update);
        void DeleteRequest(GuestRequest newRequest);//מוסיף דרישת אירוח חדשה

        HostingUnit GetUnit(int id);
        void AddUnit(HostingUnit newUnit);//הוספת יחידת אירוח
        void UpdateUnit(HostingUnit update);
        void DeleteUnit(HostingUnit delUnit);

        Order GetOrder(int id);
        void AddOrder(Order newOrder);//מוסיף הזמנה לרשימה
        void UpdateOrder(Order update);
        void DeleteOrder(Order update);

        List<HostingUnit> GetUnitsList ();// מחזיר רשימת אירוח
        List<GuestRequest> GetGuestRequestList ();// מחזיר רשימת בקשות אירוח
        List<Order> GetOrdersList();//מחזיר רשימת הזמנות
        List<BankBranch> GetBankList();
    }
}
