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
        void updateRequest(GuestRequest update);//עידכון דרישת לקוח- עידכון סטטוס
        void addUnit(HostingUnit newUnit);//הוספת יחידת אירוח
        void deleteUnit(HostingUnit delUnit);//מחיקת יחידת אירוח שלמה
        void updateUnit(HostingUnit update);//עידכון יחידת אירוח לפי כל השדות שלה
        void addOrder(Order newOrder);//מוסיף הזמנה לרשימה
        void updateOrder(Order update);//עידכון הזמנה לפי סטטוס
        List<HostingUnit> getUnitsList();// מחזיר רשימת אירוח
        List<GuestRequest> getCustomersList();// מחזיר רשימת בקשות אירוח
        List<Order> getOrdersList();//מחזיר רשימת הזמנות
        List<string> getBankList(List<BankBranch> bankLists);
        bool availableDate(HostingUnit H, GuestRequest G);
        bool availableDate(HostingUnit H, DateTime D, int amount);
        bool sendOrder(Host H, Order O);
        List<HostingUnit> availableUnit(List<HostingUnit> getUnitList, DateTime date, int amount);
        int amountOfDays(DateTime D1, DateTime D2);
        List<Order> howManyOrders(int amountOfDays, List<Order> orderList);
        int amountOfOrders(HostingUnit H, List<Order> orderList);
        void InvalidDate(GuestRequest gr);
    }
}