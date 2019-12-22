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
    }
    public void InvalidDate(List<GuestRequest> getCustomersList)//פונקציה שבודקת האם יום הכניסה קודם ליום היציאה
    {
        foreach (var item in getCustomersList)
        {
            if ((GuestRequest.EntryDate.day > GuestRequest.RealeseDate.day) && (GuestRequest.EntryDate.month == GuestRequest.RealeseDate.month))|| (GuestRequest.EntryDate.month > GuestRequest.RealeseDate.month);
            { break; }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Sorry, invalid input, please try again. ");
                Console.ResetColor();
                Console.WriteLine("Please enter the date you want to reserve.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                Console.WriteLine();
                Console.WriteLine("please enter the date you want to leave.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                Console.WriteLine();


            }
        }
    }

    public void AvailableDates(List<GuestRequest> getCustomersList)//פונקציה שבודקת האם התאריכים שמישהו רוצה לשהות במקום מסויים פנויים
    {

    }

}