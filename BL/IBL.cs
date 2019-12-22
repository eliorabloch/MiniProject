using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    public interface IBL
    {
        void addRequest(GuestRequest newRequest);//מוסיף דרישת אירוח חדשה
        void updateRequest(GuestRequest update);
        void addUnit(HostingUnit newUnit);//הוספת יחידת אירוח
        void deleteUnit(HostingUnit delUnit);
        void updateUnit(HostingUnit update);
        void addOrder(Order newOrder);//מוסיף הזמנה לרשימה
        void updateOrder(Order update);
        List<HostingUnit> getUnitsList();// מחזיר רשימת אירוח
        List<GuestRequest> getCustomersList();// מחזיר רשימת בקשות אירוח
        List<Order> getOrdersList();//מחזיר רשימת הזמנות
        List<string> getBankList(List<BankBranch> bankLists);
        bool availableDate(HostingUnit H, GuestRequest G);
        bool availableDate(HostingUnit H, DateTime d, int amount);
        void sendOrder(Host h, Order o);
        List<HostingUnit> availableUnit(List<HostingUnit> getUnitList, DateTime date, int amount);
        int amountOfDays(DateTime D1, DateTime D2);
        List<Order> howManyOrders(int amountOfDays, List<Order> orderList);
        int amountOfOrders(HostingUnit h, List<Order> orderList);
    }




}