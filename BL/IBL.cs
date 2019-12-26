using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    public interface IBL
    {
        // Mirror of DAL functions
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

        List<HostingUnit> GetUnitsList();// מחזיר רשימת אירוח
        List<GuestRequest> GetGuestRequestList();// מחזיר רשימת בקשות אירוח
        List<Order> GetOrdersList();//מחזיר רשימת הזמנות
        List<BankBranch> GetBankList();



        // BL new  function
        bool AvailableDate(HostingUnit h, GuestRequest g);
        List<HostingUnit> GetAllAvilableUnits(HostingUnit unit, DateTime start, int amountOfDAys);
        bool SendOrder(Host h, Order o);
         double AmountOfDays(DateTime start, DateTime end);
        List<Order> GetOldOrders(int amountOfDays);
        List<GuestRequest> GetAllGuestRequest(Predicate<GuestRequest> condition);
        int GetNumOfOrders(GuestRequest gr);
        int GetNumOfSentOrders(HostingUnit hu);

        List<List<GuestRequest>> GroupGuestRequestByAreas();
        List<List<GuestRequest>> GroupGuestRequestByNumOfAtendees();
        List<List<Host>> GroupHostsByNumOfUnits();
        List<List<HostingUnit>> GroupHostingUnitsByArea();
    }
}