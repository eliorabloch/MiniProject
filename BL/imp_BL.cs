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
    class ImpBL : IBL
    {
        #region Singleton
        private static readonly ImpBL instance = new ImpBL();

        public static ImpBL Instance
        {
            get { return instance; }
        }

        #endregion

        static IDAL dal;

        static ImpBL()
        {
            string TypeDAL = ConfigurationSettings.AppSettings.Get("TypeDS");
            //string TypeDAL = "List";
            dal = factoryDAL.GetDAL(TypeDAL);
        }


        #region Gusets Requsts

        public GuestRequest GetRequest(int id)
        {
            return getGuestRequestIfExists(id);
        }

        public void AddRequest(GuestRequest newRequest)
        {
            validGuestRequest(newRequest);

            if (newRequest.Status != RequestStatus.Open)
            {
                throw new TzimerException("Sorry, new request must be in status - 'open'", "bl");
            }
            dal.AddRequest(newRequest);
        }


        public void UpdateRequest(GuestRequest updatedRequest)
        {
            validGuestRequest(updatedRequest);

            GuestRequest oldReq = getGuestRequestIfExists(updatedRequest.GuestRequestKey);

            if (oldReq.Status == RequestStatus.ClosedDeal || oldReq.Status == RequestStatus.ExpiredRequest)
            {
                throw new TzimerException($"Cannot update a closed request, Request ID: {updatedRequest.GuestRequestKey}", "bl");
            }

            dal.UpdateRequest(updatedRequest);
        }

        static Func<int, GuestRequest> getGuestRequestIfExists = delegate (int id)
         {
             var oldReq = dal.GetRequest(id);
             if (oldReq == null)
             {
                 throw new TzimerException($"Cannot find Requst with ID: {id}", "bl");
             }
             return oldReq;
         };

        public void DeleteRequest(GuestRequest request)
        {
            getGuestRequestIfExists(request.GuestRequestKey);
            dal.DeleteRequest(request);
        }

        private void validGuestRequest(GuestRequest newRequest)
        {
            if ((newRequest.ReleaseDate - newRequest.EntryDate).TotalDays < 1)
            {
                throw new TzimerException("Sorry, the dates you choose are invalid, entry must be before leave!", "bl");
            }

            if (string.IsNullOrEmpty(newRequest.FamilyName))
            {
                throw new TzimerException("Please enter your family name", "bl");
            }
            if (string.IsNullOrEmpty(newRequest.PrivateName))
            {
                throw new TzimerException("Please enter your private name", "bl");
            }
            if (string.IsNullOrEmpty(newRequest.MailAddress))
            {
                throw new TzimerException("Please enter your e-mail address", "bl");
            }
            if (newRequest.Adults == 0)
            {
                throw new TzimerException("Cannot set request with zero adults!", "bl");
            }
        }

        #endregion


        #region Hosting Units

        static Func<int, HostingUnit> getHostingUnitsIfExists = delegate (int id)
        {
            var oldUnit = dal.GetUnit(id);
            if (oldUnit == null)
            {
                throw new TzimerException($"Cannot find Unit with ID: {id}", "bl");
            }
            return oldUnit;
        };

        public HostingUnit GetUnit(int id)
        {

            return getHostingUnitsIfExists(id);
        }

        public void AddUnit(HostingUnit newUnit)
        {
            validHostingUnit(newUnit);
            dal.AddUnit(newUnit);
        }

        public void UpdateUnit(HostingUnit updatedUnit)
        {
            getHostingUnitsIfExists(updatedUnit.HostingUnitKey);
            dal.UpdateUnit(updatedUnit);
        }

        public void DeleteUnit(HostingUnit delUnit)
        {
            getHostingUnitsIfExists(delUnit.HostingUnitKey);
            if (isHaveOpenOrder(delUnit))
            {
                throw new TzimerException("Cannot delete Host Unit that has active deals", "bl");
            }
            dal.DeleteUnit(delUnit);
        }

        private static bool isHaveOpenOrder(HostingUnit unit)
        {
            return dal.GetOrdersList().Any(x => x.HostingUnitKey == unit.HostingUnitKey && (x.Status == OrderStatus.NotHandled || x.Status == OrderStatus.SentMail));
        }

        private void validHostingUnit(HostingUnit newUnit)
        {
            if (string.IsNullOrEmpty(newUnit.HostingUnitName))
            {
                throw new TzimerException("Please enter your Host name", "bl");
            }
        }

        public List<HostingUnit> GetUnitsList()
        {
            return dal.GetUnitsList();
        }

        #endregion

        #region Orders

        static Func<int, Order> getOrderIfExists = delegate (int id)
        {
            var oldOrder = dal.GetOrder(id);
            if (oldOrder == null)
            {
                throw new TzimerException($"Cannot find Order with ID: {id}", "bl");
            }
            return oldOrder;
        };

        public Order GetOrder(int id)
        {
            return getOrderIfExists(id);
        }

        public void AddOrder(Order newOrder)
        {
            var req = getGuestRequestIfExists(newOrder.GuestRequestKey);
            var unit = getHostingUnitsIfExists(newOrder.HostingUnitKey);
            if (!AvailableDate(unit, req))
            {
                throw new TzimerException("Sorry, those dates are taken, please choose a new date", "bl");
            }
            dal.AddOrder(newOrder);
        }

        public void UpdateOrder(Order updatedOrder)
        {
            var oldOrder = getOrderIfExists(updatedOrder.OrderKey);
            var req = getGuestRequestIfExists(updatedOrder.GuestRequestKey);
            var unit = getHostingUnitsIfExists(updatedOrder.HostingUnitKey);
            if (oldOrder.Status == OrderStatus.ClosedRequestCanceled || oldOrder.Status == OrderStatus.ClosedRequestDoneDeal)
            {
                throw new TzimerException("Sorry, this order already closed", "bl");
            }
            if(updatedOrder.Status == OrderStatus.ClosedRequestDoneDeal)
            {
                var totalDays = (req.ReleaseDate - req.EntryDate).TotalDays;
                Configuration.Profits += (totalDays * Configuration.Commissin);
                updateDatesAvilable(unit, req);
                cancelAllOtherOrders(updatedOrder);
            }
            else if (updatedOrder.Status == OrderStatus.SentMail)
            {
                sendOrderRequest(req);
            }

        }

       
        #endregion



        public List<HostingUnit> GetAllAvilableUnits(HostingUnit unit, DateTime start, int amountOfDAys)
        {

            DateTime end = start.AddDays(amountOfDAys);
            return GetUnitsList().Where(x => isDatesAvilable(x, start, end)).ToList();
        }

        void updateDatesAvilable(HostingUnit unit, GuestRequest req)
        {
            DateTime tempDate = req.EntryDate;
            while (tempDate < req.ReleaseDate)
            {
                unit.Diary[tempDate.Month - 1, tempDate.Day - 1] = true;
                tempDate.AddDays(1);
            }
        }

        static void cancelAllOtherOrders(Order order)
        {
            dal.GetOrdersList().ForEach(o => {
                if (o.GuestRequestKey == order.GuestRequestKey && o.OrderKey != order.OrderKey)
                {
                    o.Status = OrderStatus.ClosedRequestCanceled;
                    dal.UpdateOrder(o);
                }
            });
        }

        public List<GuestRequest> GetGuestRequestList()
        {
            return dal.GetGuestRequestList();
        }

        public List<Order> GetOrdersList()
        {
            return dal.GetOrdersList();
        }

        public List<BankBranch> GetBankList()
        {
           return dal.GetBankList();
        }

        public bool SendOrder(Host h, Order o)//אם הלקוח חתם על טופס הרשאה של הבנק המארח יוכל לשלוח לו הזמנה
        {
            if (h.CollectionClearance)
            {
                o.Status = OrderStatus.SentMail;
                UpdateOrder(o);
                return true;
            }
            return false;
        }

        void sendOrderRequest(GuestRequest gr)
        {
            // TODO: send request in SMTP to Mail server
        }

        bool isDatesAvilable(HostingUnit unit, DateTime start, DateTime end)
        {
            DateTime tempDate = start;
            while (tempDate < end)
            {
                if (unit.Diary[tempDate.Month - 1, tempDate.Day - 1])
                {
                    return false;
                }
                tempDate.AddDays(1);
            }
            return true;
        }

        bool availableDate(HostingUnit h, DateTime start, int amount)//פונקציה שמוודאת התאריכים שהוזמנו פנויים ביחידה שאליה שיבצו את ההזמנה
        {
            DateTime end = start.AddDays(amount);
            return isDatesAvilable(h, start, end);
        }


        public double AmountOfDays(DateTime start, DateTime end)//פונקציה שמקבלת שני תאריכים ובודקת מה ההפרש ביניהם
        {//צריך לטפל באיתחול הדיפולטיבי של D2 שיהיה NOW
            end = end == null ? DateTime.Now : end;
            return (end - start).TotalDays;
        }

        public bool AvailableDate(HostingUnit h, GuestRequest g)
        {
            return isDatesAvilable(h, g.EntryDate, g.ReleaseDate);
        }


        public List<GuestRequest> GetAllGuestRequest(Predicate<GuestRequest> condition)
        {
            return GetGuestRequestList().Where(x => condition(x)).ToList();
        }

        public int GetNumOfOrders(GuestRequest gr)
        {
            return GetOrdersList().Where(x => x.GuestRequestKey == gr.GuestRequestKey).Count();
        }

        public int GetNumOfSentOrders(HostingUnit hu)
        {
            return GetOrdersList().Where(x => x.HostingUnitKey == hu.HostingUnitKey && 
            (x.Status == OrderStatus.SentMail || x.Status == OrderStatus.ClosedRequestDoneDeal)).Count();
        }

        Func<Order, int, bool> isOldOrder = delegate (Order order, int amountOfDays)
        {
            DateTime start = order.OrderDate > order.CreateDate ? order.CreateDate : order.OrderDate;
            DateTime end = DateTime.Now;
            return (end - start).TotalDays >= amountOfDays;
        };

        public List<Order> GetOldOrders(int amountOfDays)//פונקציה שמחזירה רשימה של הזמנות שהזמו שעבר ממתי שהם אושרו או שנשלח מייל ללקוח שווה למספר הימים שקיבלנו
        {
            return GetOrdersList().Where(x => isOldOrder(x, amountOfDays)).ToList();
        }

        int amountOfOrders(HostingUnit h,List<Order> orderList)//פונקציה שמקבלת דרישת לקוח, ומחזירה את מספר ההזמנות שנשלחו אליו
        {
            int sum = 0;
            foreach(var item in orderList)
            {
                if(item.HostingUnitKey==h.HostingUnitKey)
                {
                    if (item.Status== OrderStatus.ClosedRequestCanceled|| item.Status == OrderStatus.ClosedRequestDoneDeal)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }


        public List<List<GuestRequest>> GroupGuestRequestByAreas()
        {
            return (from gr in GetGuestRequestList()
                       group gr by gr.Area into g
                       select g.ToList()).ToList();

        }

        public List<List<GuestRequest>> GroupGuestRequestByNumOfAtendees()
        {
            return (from gr in GetGuestRequestList()
                    group gr by gr.Children + gr.Adults into g
                    select g.ToList()).ToList();

        }

        public List<List<Host>> GroupHostsByNumOfUnits()
        {
            return (from h in getHostsList()
                    group h by getNumOfUnits(h) into g
                    select g.ToList()).ToList();
        }

        private List<Host> getHostsList()
        {
            return GetUnitsList().Select(x => x.Owner).Distinct().ToList();
        }

        private int getNumOfUnits(Host owner)
        {
            return GetUnitsList().Sum(x => x.Owner.HostKey == owner.HostKey ? 1 : 0);
        }

       
        public void DeleteOrder(Order update)
        {
            
        }

       
    }
}


   

