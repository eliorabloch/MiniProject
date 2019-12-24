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

        void InvalidDate(GuestRequest gr)//פונקציה שבודקת האם יום הכניסה קודם ליום היציאה
        {
            // if (!(((gr.EntryDate.Day < gr.ReleaseDate.Day) && (gr.EntryDate.Month == gr.ReleaseDate.Month)) || (gr.EntryDate.Month < gr.ReleaseDate.Month)))
            if (gr.EntryDate < gr.ReleaseDate)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Sorry, invalid date, please try again.");
                Console.ResetColor();
                Console.WriteLine("Please enter the date you want to reserve.");
                Console.WriteLine("The format must be yyyy-mm-dd.");
                Console.WriteLine();
                Console.WriteLine("Please enter the date you want to leave.");
                Console.WriteLine("The format must be yyyy-mm-dd.");
                Console.WriteLine();
            }
        }

        List<HostingUnit> availableUnit(List<HostingUnit> getUnitList, DateTime date, int amount)//פונקציה שמחזירה רשימה של יחידות אירוח שפנויות בתאריך מסויים
        {
            List<HostingUnit> mylist = new List<HostingUnit>();
            foreach (var item in getUnitList)
            {
                if (availableDate(item, date, amount))
                {
                    mylist.Add(item);
                }
            }
            return mylist;
        }

        bool sendOrder(Host H, Order O)//אם הלקוח חתם על טופס הרשאה של הבנק המארח יוכל לשלוח לו הזמנה
        {
            if (H.CollectionClearance)
            {
                O.Status = OrderStatus.SentMail;
                return true;
            }
            return false;
        }

        bool availableDate(HostingUnit H, DateTime d, int amount)//פונקציה שמוודאת התאריכים שהוזמנו פנויים ביחידה שאליה שיבצו את ההזמנה
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

        int amountOfDays(DateTime D1, DateTime D2)//פונקציה שמקבלת שני תאריכים ובודקת מה ההפרש ביניהם
        {//צריך לטפל באיתחול הדיפולטיבי של D2 שיהיה NOW
            int amount = 0;
            if (D1.Month == D2.Month)
            { amount = D2.Day - D1.Day; }
            else amount = (D2.Day - D1.Day) + 31;
            return amount;
        }

        List<Order> howManyOrders(int amountOfDays, List<Order> orderList)//פונקציה שמחזירה רשימה של הזמנות שהזמו שעבר ממתי שהם אושרו או שנשלח מייל ללקוח שווה למספר הימים שקיבלנו
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
                    {
                        myList.Add(item);
                    }
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

        int amountOfOrders(HostingUnit h,List<Order> orderList)//פונקציה שמקבלת דרישת לקוח, ומחזירה את מספר ההזמנות שנשלחו אליו
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




        //הוספתי את מה שהוא ביקש על הפונקציות- צריך לבדוק אם צריך לממש את זה שוב
        public void addRequest(GuestRequest newRequest)
        {
            throw new NotImplementedException();
        }

        public void updateRequest(GuestRequest update)
        {
            throw new NotImplementedException();
        }

        public void addUnit(HostingUnit newUnit)
        {
            throw new NotImplementedException();
        }

        public void deleteUnit(HostingUnit delUnit)
        {
            throw new NotImplementedException();
        }

        public void updateUnit(HostingUnit update)
        {
            throw new NotImplementedException();
        }

        public void addOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public void updateOrder(Order update)
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> getUnitsList()
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> getCustomersList()
        {
            throw new NotImplementedException();
        }

        public List<Order> getOrdersList()
        {
            throw new NotImplementedException();
        }

        public List<string> getBankList(List<BankBranch> bankLists)
        {
            throw new NotImplementedException();
        }

        bool IBL.availableDate(HostingUnit H, GuestRequest G)
        {
            throw new NotImplementedException();
        }

        bool IBL.availableDate(HostingUnit H, DateTime D, int amount)
        {
            throw new NotImplementedException();
        }

        void IBL.sendOrder(Host H, Order O)
        {
            throw new NotImplementedException();
        }

        List<HostingUnit> IBL.availableUnit(List<HostingUnit> getUnitList, DateTime date, int amount)
        {
            throw new NotImplementedException();
        }

        int IBL.amountOfDays(DateTime D1, DateTime D2)
        {
            throw new NotImplementedException();
        }

        List<Order> IBL.howManyOrders(int amountOfDays, List<Order> orderList)
        {
            throw new NotImplementedException();
        }

        int IBL.amountOfOrders(HostingUnit H, List<Order> orderList)
        {
            throw new NotImplementedException();
        }

        void IBL.InvalidDate(GuestRequest gr)
        {
            throw new NotImplementedException();
        }
    }
}


   

