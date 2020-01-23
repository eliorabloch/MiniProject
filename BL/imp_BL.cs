using DAL;
using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;


using System.Net.Mail;
namespace BL
{
    public class ImpBL : IBL
    {

        #region Singleton

        /// <summary>
        /// //Using Singleton makes sure that no new instance of the class is ever created but only one instance.
        /// </summary>
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
            dal = factoryDAL.GetDAL(TypeDAL);
            
        }
        public ImpBL()
        {
            Thread thread = new Thread(() => checkAndChangeStatusOrder());
            thread.Start();
        }


        #region Gusets Requsts

        /// <summary>
        ///  Fanction who search for a guest requests by its key.
        /// </summary>
        /// <param name="hostingUnit">list of guest requests</param>
        /// <param name="key">unit key</param>
        /// <returns>guest request when given his request key.</returns>
        public List<GuestRequest> searchByKey(string key)
        {
            return GetGuestRequestList().Where(x => x.GuestRequestKey.ToString().StartsWith(key)).ToList();
        }

        /// <summary>
        ///  Fanction who search for a guest requests by its key.
        /// </summary>
        /// <param name="hostingUnit">list of guest requests</param>
        /// <param name="key">request key</param>
        /// <returns>guest requests when given his request key.</returns>
        public List<GuestRequest> searchByName(string familyName)
        {
            return GetGuestRequestList()
                .Where(x=>x.FamilyName.ToLower().StartsWith(familyName.ToLower())).ToList();
        }

        public GuestRequest GetRequest(int id)
        {
            return getGuestRequestIfExists(id);
        }

        /// <summary>
        /// function who get the all units one host has.
        /// </summary>
        /// <param name="hostId">string</param>
        /// <returns>hosting units list</returns>
        public List<HostingUnit> GetUnitsByHost(string hostId)
        {
            return GetUnitsList().Where(x => x.Owner.HostId == hostId).ToList();
        }

        /// <summary>
        /// function who match between request to unit.
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <returns>guest requests list</returns>
        public List<GuestRequest> matchRequestToUnit(HostingUnit unit, string subAreaFilter, string attendantsAmount)
        {
            return GetGuestRequestList().Where(grItem => checkIfUnitMatchToRequest(unit, grItem, subAreaFilter, attendantsAmount) != null ).ToList();
        }

        /// <summary>
        /// function who check the match between unit to request.
        /// </summary>
        /// <param name="hu">hosting unit</param>
        /// <param name="gr">guest request</param>
        /// <returns>the guest request if there is a match.</returns>
        public GuestRequest checkIfUnitMatchToRequest(HostingUnit hu, GuestRequest gr, string subAreaFilter, string attendantsAmount)
        {
            if(GetOrdersList().Any(o=>o.GuestRequestKey==gr.GuestRequestKey && o.HostingUnitKey == hu.HostingUnitKey))
            {
                return null;
            }

            int attendants;
            var filterAttendants = int.TryParse(attendantsAmount, out attendants);

            if (
                hu.Area == gr.Area
                && hu.Type == gr.Type
                && isDatesAvilable(hu, gr.EntryDate, gr.ReleaseDate)
                && filterAttendants ? int.Parse(gr.Children) + int.Parse(gr.Adults) == attendants : true
                && gr.SubArea.ToLower().StartsWith(subAreaFilter.ToLower())
                && isMatchRequirment(hu.Pool, gr.Pool)
                && isMatchRequirment(hu.Jacuzz, gr.Jacuzzi)
                && isMatchRequirment(hu.Garden, gr.Garden)
                && isMatchRequirment(hu.ChildrensAttractions, gr.ChildrensAttractions)
                && isMatchRequirment(hu.breakfastIncluded, gr.breakfastIncluded)
                && isMatchRequirment(hu.FreeParking, gr.FreeParking)
                && isMatchRequirment(hu.RoomService, gr.RoomService)
                )
            {
                return gr;
            }

            return null;
        }

        /// <summary>
        /// function who matching between property to unit.
        /// </summary>
        /// <param name="hasOption">bool</param>
        /// <param name="requrement">options</param>
        /// <returns>true if there is a match and false if not.</returns>
        bool isMatchRequirment(bool hasOption, Options requrement)
        {
            return !(!hasOption && requrement == Options.neccesery);
        }

        /// <summary>
        /// function who arrange the guest requests by their status (grouping).
        /// </summary>
        /// <returns>guest requests list sorted by theie status.</returns>
        public List<List<GuestRequest>> GroupRequesteByStatus()
        {
            return (from gr in GetGuestRequestList()
                    group gr by gr.Status into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// function who give me host by his id number.
        /// </summary>
        /// <param name="hostId">string</param>
        /// <returns>host</returns>
        public Host GetHost(string hostId)
        {
            var hu = GetUnitsList().FirstOrDefault(x => x.Owner.HostId == hostId);
            if (hu != null)
            {
                return hu.Owner;
            }
            else
            {
                throw new TzimerException($"Sorry, cannot find host with ID: {hostId}", "bl");
            }
        }

        /// <summary>
        /// A function that adds a new hosting requirement.
        /// </summary>
        /// <param name="newRequest">Adding a request.</param>
        public void AddRequest(GuestRequest newRequest)
        {
            validGuestRequest(newRequest);

            if (newRequest.Status != RequestStatus.Open)
            {
                throw new TzimerException("Sorry, new request must be in status - 'open'", "bl");
            }
            dal.AddRequest(newRequest);
        }

        /// <summary>
        /// A function that updates a hosting requirement.
        /// </summary>
        /// <param name="update">Updating request.</param>
        public void UpdateRequest(GuestRequest updatedRequest)
        {
            validGuestRequest(updatedRequest);

            GuestRequest oldReq = getGuestRequestIfExists(updatedRequest.GuestRequestKey);

            if ((updatedRequest.Status != RequestStatus.ClosedDeal && oldReq.Status == RequestStatus.ClosedDeal )
                ||
                (updatedRequest.Status != RequestStatus.ExpiredRequest && oldReq.Status == RequestStatus.ExpiredRequest))
            {
                throw new TzimerException($"Cannot update a closed request, Request ID: {updatedRequest.GuestRequestKey}", "bl");
            }

            dal.UpdateRequest(updatedRequest);
        }

        /// <summary>
        /// A delegate function that accepts any guest request and checks by its ID whether it already exists, if it does not throw an exception, else returns the request.
        /// </summary>
        static Func<int, GuestRequest> getGuestRequestIfExists = delegate (int id)
        {
            var oldReq = dal.GetRequest(id);
            if (oldReq == null)
            {
                throw new TzimerException($"Cannot find Requst with ID: {id}", "bl");
            }
            return oldReq;
        };

        /// <summary>
        /// A function that deletes a new hosting requirement
        /// </summary>
        /// <param name="newRequest">Deleted request.</param>
        public void DeleteRequest(GuestRequest request)
        {
            getGuestRequestIfExists(request.GuestRequestKey);
            dal.DeleteRequest(request);
        }

        /// <summary>
        /// Function that checks the integrity of the guest request.
        /// </summary>
        /// <param name="newRequest"></param>
        private void validGuestRequest(GuestRequest newRequest)
        {
            if ((newRequest.ReleaseDate - newRequest.EntryDate).TotalDays < 1)
            {
                throw new TzimerException("Sorry, the dates you chose are invalid, entry must be before leave!", "bl");
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
            if (string.IsNullOrEmpty(newRequest.PhoneNumber))
            {
                throw new TzimerException("Please enter your phone number", "bl");
            }

            if (!(newRequest.MailAddress.Contains("@")))
            {
                throw new TzimerException("E-mail Address format is invaled.Please enter the correct format.", "bl");
            }
            if (string.IsNullOrEmpty(newRequest.Children))
            {
                throw new TzimerException("Please enter the amount of children", "bl");

            }
            if (string.IsNullOrEmpty(newRequest.Adults))
            {
                throw new TzimerException("Please enter the amount of adults", "bl");

            }
            int number;
            bool checknumber = Int32.TryParse(newRequest.PhoneNumber, out number);
            if (!checknumber)
            {
                throw new TzimerException("Phone number may contain only numbers.", "bl");

            }
            //If the number of adults is equal to 0, an exception is sent.
            if (newRequest.Adults == "0")
            {
                throw new TzimerException("Cannot set request with zero adults!", "bl");
            }
        }

        #endregion

        #region Hosting Units
        

        /// <summary>
        /// Fanction who search for a hosting units by its key.
        /// </summary>
        /// <param name="hostingUnit">hosting unit</param>
        /// <param name="key">int</param>
        /// <returns>hosting units when given his unit key.</returns>
        public HostingUnit searchByKey(List<HostingUnit> hostingUnit, int key = -1)
        {
            foreach (var item in hostingUnit)
            {
                if (item.HostingUnitKey == key)
                {
                    return item;
                }
            }
            throw new TzimerException($"Sorry,cant find a request with the key{key}", "bl");
        }

        /// <summary>
        /// Fanction who search for a hosting units by its name.
        /// </summary>
        /// <param name="hostingUnit">hosting unit</param>
        /// <param name="key">int</param>
        /// <returns>hosting units when given his unit name.</returns>
        public List<HostingUnit> searchByName(List<HostingUnit> HostingUnit, string Name)
        {
            bool ifExist = false;
            List<HostingUnit> nameHU = new List<HostingUnit>();
            foreach (var item in HostingUnit)
            {
                if (item.HostingUnitName == Name)
                {
                    nameHU.Add(item);
                    ifExist = true;
                }

            }


            if (ifExist)
            {
                return nameHU;
            }

            else
                throw new TzimerException($"Sorry,cant find a request with the name:{Name}", "bl");
        }
        
        /// <summary>
        /// A delegate function that accepts any hosting unit and checks by its ID whether it already exists, if it does not throw an exception, else returns the unit.
        /// </summary>
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

        /// <summary>
        /// A function that adds a hosting unit.
        /// </summary>
        /// <param name="update">Updating hostingunit.</param>
        public void AddUnit(HostingUnit newUnit)
        {
            validHostingUnit(newUnit);
            dal.AddUnit(newUnit);
        }

        /// <summary>
        /// A function that updates a hosting unit.
        /// </summary>
        /// <param name="delUnit">Deleted request.</param>
        public void UpdateUnit(HostingUnit updatedUnit)
        {
            getHostingUnitsIfExists(updatedUnit.HostingUnitKey);
            dal.UpdateUnit(updatedUnit);
        }

        /// <summary>
        /// A function that deletes a hosting unit.
        /// </summary>
        /// <param name="delUnit">Deleted hostingunit</param>
        public void DeleteUnit(HostingUnit delUnit)
        {
            getHostingUnitsIfExists(delUnit.HostingUnitKey);
            if (isHaveOpenOrder(delUnit))
            {
                throw new TzimerException("Cannot delete Host Unit that has active deals", "bl");
            }
            dal.DeleteUnit(delUnit);
        }

        /// <summary>
        ///A function that goes through the order list and checks for an open order. 
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <returns>if there is an open order</returns>
        private static bool isHaveOpenOrder(HostingUnit unit)
        {
            return dal.GetOrdersList().Any(x => x.HostingUnitKey == unit.HostingUnitKey && (x.Status == OrderStatus.NotHandled || x.Status == OrderStatus.SentMail));
        }

        /// <summary>
        /// If the hosting unit does not have a name - we will throw an error asking you to re-enter the unit name.
        /// </summary>
        /// <param name="newUnit">hosting unit</param>
        private void validHostingUnit(HostingUnit newUnit)
        {
            if (string.IsNullOrEmpty(newUnit.HostingUnitName))
            {
                throw new TzimerException("Please enter your Host name", "bl");
            }
        }

        /// <summary>
        ///  A function that returns a hosting unit list.
        /// </summary>
        /// <returns>All hosting units list.</returns>
        public List<HostingUnit> GetUnitsList()
        {
            return dal.GetUnitsList();
        }

        #endregion

        #region Orders

        /// <summary>
        /// function who return an order list who reflected to unit by his unit key.
        /// </summary>
        /// <param name="hostingUnitKey">int</param>
        /// <returns>orders list</returns>
        public List<Order> GetOrdersByUnit(int hostingUnitKey)
        {
            return GetOrdersList().Where(x => x.HostingUnitKey == hostingUnitKey).ToList();
        }
       
        /// <summary>
        /// Fanction who search for a orders by its key.
        /// </summary>
        /// <param name="order">order</param>
        /// <param name="key">int</param>
        /// <returns>order when given his order key.</returns>
        public Order searchByKey(List<Order> order, int key = -1)
        {
            foreach (var item in order)
            {
                if (item.OrderKey == key)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// A delegate function that accepts any order and checks by its ID whether it already exists, if it does not throw an exception, else returns the order.
        /// </summary>
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

        /// <summary>
        /// A function that adds an order to the list.
        /// </summary>
        /// <param name="newOrder">Adding order</param>
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

        /// <summary>
        /// Function that updates an order.
        /// </summary>
        /// <param name="update">Updated order.</param>
        public void UpdateOrder(Order updatedOrder)
        {
            var oldOrder = getOrderIfExists(updatedOrder.OrderKey);
            var req = getGuestRequestIfExists(updatedOrder.GuestRequestKey);
            var unit = getHostingUnitsIfExists(updatedOrder.HostingUnitKey);
            if (oldOrder.Status == OrderStatus.Canceled || oldOrder.Status == OrderStatus.DoneDeal)
            {
                throw new TzimerException("Sorry, this order already closed", "bl");
            }
            if (updatedOrder.Status == OrderStatus.DoneDeal)
            {
                var totalDays = (req.ReleaseDate - req.EntryDate).TotalDays;
                Configuration.Profits += (totalDays * Configuration.Commissin);
                updateDatesAvilable(unit, req);
                UpdateUnit(unit);
                cancelAllOtherOrders(updatedOrder);
                req.Status = RequestStatus.ClosedDeal;
            } 
            if (updatedOrder.Status == OrderStatus.Canceled)
            {
                req.Status = RequestStatus.ExpiredRequest;
            }
            if (updatedOrder.Status == OrderStatus.NotHandled)
            {
                req.Status = RequestStatus.Open;
            }
            UpdateRequest(req);
            dal.UpdateOrder(updatedOrder);
        }

        #endregion


        /// <summary>
        /// function who check if more then 30 days were pass from the date the mail send till now, if so- update the status.
        /// </summary>
        /// <param name="updatedOrderStatus">order</param>
        public void checkAndChangeStatusOrder()
        {
            if (Convert.ToDateTime(Configuration.Date) != DateTime.Now)//check bug
            {
                Configuration.Date = DateTime.Now.ToString("yyyy/M/dd ");

                foreach (var updatedOrderStatus in GetOrdersList())
                {
                    if ((int)AmountOfDays(updatedOrderStatus.OrderDate, DateTime.Now) > 30)
                    {
                        updatedOrderStatus.Status = OrderStatus.Canceled;
                    }
                    dal.UpdateOrder(updatedOrderStatus);
                }
            }
        }

        //private static System.Timers.Timer aTimer;
        //public void timerClass()
        //{
        //    Timer timer = new Timer(86400);
        //    timer.Elapsed += async (sender, e) => await HandleTimer();
        //    timer.Start();
        //}
        //private static Task HandleTimer()
        //{
        //    throw new TzimerException("");
        //}
        //private static void SetTimer()
        //{
        //    aTimer = new System.Timers.Timer(2000);
        //    aTimer.Elapsed += OnTimedEvent;
        //    aTimer.AutoReset = true;
        //    aTimer.Enabled = true;
        //}
        //private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //    throw new TzimerException("The Elapsed event was raised at {0:HH:mm:ss.fff}");
        //}
        //public static void Main()
        //{
        //    SetTimer();
        //    Console.ReadLine();
        //    aTimer.Stop();
        //    aTimer.Dispose();

        //    Console.WriteLine("Terminating the application...");
        //}

        /// <summary>
        /// function who goes to the DAL and give me the uest request list.
        /// </summary>
        /// <returns>guest requests lits</returns>
        public List<GuestRequest> GetGuestRequestList()
        {
            return dal.GetGuestRequestList();
        }

        /// <summary>
        /// function who goes to the DAL and give me the order list.
        /// </summary>
        /// <returns>orders lits</returns>
        public List<Order> GetOrdersList()
        {
            return dal.GetOrdersList();
        }

        /// <summary>
        /// function who goes to the DAL and give me the host list.
        /// </summary>
        /// <returns>hosts lits</returns>
        public List<Host> GetHostsList()
        {
            return dal.GetHostList();
        }

        /// <summary>
        /// function who goes to the DAL and give me the bank list.
        /// </summary>
        /// <returns>bank branchs lits</returns>
        public List<BankBranch> GetBankList()
        {
            return dal.GetBankList();
        }
        
        /// <summary>
        /// A function that accepts a date and number of vacation days and returns the list of all available accommodation units on that date.
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="amountOfDAys">Amount of dates the guest want to stay at the hostingUnit.</param>
        /// <returns>List with all the available units at some dates.</returns>
        public List<HostingUnit> GetAllAvilableUnits(DateTime start, int amountOfDAys)
        {
            DateTime end = start.AddDays(amountOfDAys);
            return GetUnitsList().Where(x => isDatesAvilable(x, start, end)).ToList();
        }
      
        /// <summary>
        /// A function that checks whether an order can be sent to a customer. Only if the client has signed a host bank authorization form can he send an order.
        /// </summary>
        /// <param name="h">host</param>
        /// <param name="o">order</param>
        /// <param name="hu">hosting unit</param>
        /// <returns>if the hostingUnit fit to guest requst, send mail.</returns>
        public bool SendOrder(Host h, Order o, HostingUnit hostingunit)
        {
            if (h.CollectionClearance)
            {
                MailMessage mail = new MailMessage();
                GuestRequest gr = GetRequest(o.GuestRequestKey);
                mail.To.Add("eliora.bloch@gmail.com");
                mail.To.Add("lielorenstein10@gmail.com");
                mail.From = new MailAddress("VacationModePlan@gmail.com");
                mail.Body = $"Dear {gr.PrivateName}  {gr.FamilyName}, <br><br>" +
                    $"We have found a unit that matches your request number {o.GuestRequestKey}.<br>" +
                    $"The unit is called {hostingunit.HostingUnitName}.<br>" +
                    $"You may contact the units host named {h.PrivateName } {h.FamilyName} through this email address: {h.MailAddress}, or by calling this number: {h.PhoneNumber}.<br>" +
                    $"We are looking forward to closing a deal with you.<br><br>" +
                    $"Yours, VacationMode";

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("VacationModePlan@gmail.com", "vac123456");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                o.Status = OrderStatus.SentMail;
                UpdateOrder(o);
                return true;
            }
            else
            {
                return false;
            }

        }
       
        /// <summary>
        /// A function that accepts two dates and checks the time difference between them. If the function has only received one date, it will check how much time has passed from that date until now.
        /// </summary>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <returns>the amount of dates between two dates.</returns>
        public double AmountOfDays(DateTime start, DateTime end)
        {
            end = end == null ? DateTime.Now : end;
            return (end - start).TotalDays;
        }

        /// <summary>
        /// A function that makes sure the booked dates are free in the unit we placed the order.
        /// </summary>
        /// <param name="h">hosting unit</param>
        /// <param name="g">guest request</param>
        /// <returns> All available dates at hosting unit.</returns>
        public bool AvailableDate(HostingUnit h, GuestRequest g)
        {
            return isDatesAvilable(h, g.EntryDate, g.ReleaseDate);
        }

        bool availableDate(HostingUnit h, DateTime start, int amount)
        {
            DateTime end = start.AddDays(amount);
            return isDatesAvilable(h, start, end);
        }

        /// <summary>
        /// Function who checks wheter the requests are fit to some condition.
        /// </summary>
        /// <param name="condition">predicate of guest request</param>
        /// <returns>all the guest request who fit to the condition.</returns>
        public List<GuestRequest> GetAllGuestRequest(Predicate<GuestRequest> condition)
        {
            return GetGuestRequestList().Where(x => condition(x)).ToList();
        }
        
        /// <summary>
        /// function who calculate the number of sent orders.
        /// </summary>
        /// <param name="hu">hosting unit</param>
        /// <returns>the number of sent orders.</returns>
        public int GetNumOfSentOrders(HostingUnit hu)
        {
            return GetOrdersList().Where(x => x.HostingUnitKey == hu.HostingUnitKey &&
            (x.Status == OrderStatus.SentMail || x.Status == OrderStatus.DoneDeal)).Count();
        }
        
        public List<Order> GetOldOrders(int amountOfDays)
        {
            return GetOrdersList().Where(x => isOldOrder(x, amountOfDays)).ToList();
        }

        /// <summary>
        /// function who update the order status and cancel the other orders who sent to the guest.
        /// </summary>
        /// <param name="order">order</param>
        static void cancelAllOtherOrders(Order order)
        {
            dal.GetOrdersList().ForEach(o =>
            {
                if (o.GuestRequestKey == order.GuestRequestKey && o.OrderKey != order.OrderKey)
                {
                    o.Status = OrderStatus.Canceled;
                    dal.UpdateOrder(o);
                }
            });
        }

        /// <summary>
        /// If a vacant unit is on a particular date and the guest wants to be in this unit - the matrix will change the days in the unit to be occupied.
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <param name="req">guest request</param>
        void updateDatesAvilable(HostingUnit unit, GuestRequest req)
        {
            DateTime tempDate = req.EntryDate;
            while (tempDate < req.ReleaseDate)
            {
                unit.Diary[tempDate.Month - 1, tempDate.Day - 1] = true;
                tempDate = tempDate.AddDays(1);
            }
        }
        
        /// <summary>
        /// A function that checks for a particular unit is available on certain dates.
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <returns>true if the date are available and false if not.</returns>
        bool isDatesAvilable(HostingUnit unit, DateTime start, DateTime end)
        {
            DateTime tempDate = start;
            while (tempDate < end)
            {
                if (unit.Diary[tempDate.Month - 1, tempDate.Day - 1])
                {
                    return false;
                }

                tempDate = tempDate.AddDays(1);
            }
            return true;
        }

        /// <summary>
        /// function who goes over the orders list and count how many orders there are.
        /// </summary>
        /// <param name="gr">guest request</param>
        /// <returns>the number of orders we have</returns>
        public int GetNumOfOrders(GuestRequest gr)
        {
            return GetOrdersList().Where(x => x.GuestRequestKey == gr.GuestRequestKey).Count();
        }

        /// <summary>
        /// A function that accepts several days, and returns all orders that have elapsed since they were created / since the email was sent to a customer greater than or equal to the number of days the function received.
        /// </summary>
        Func<Order, int, bool> isOldOrder = delegate (Order order, int amountOfDays)
        {
            DateTime start = order.OrderDate > order.CreateDate ? order.CreateDate : order.OrderDate;
            DateTime end = DateTime.Now;
            return (end - start).TotalDays >= amountOfDays;
        };

        /// <summary>
        /// A function that goes through the order list and checks for each unit how many orders it has closed.
        /// </summary>
        /// <param name="h">hosting unit</param>
        /// <param name="orderList">list of orders</param>
        /// <returns>the amount of cloesed order for each unit.</returns>
        int amountOfOrders(HostingUnit h, List<Order> orderList)
        {
            int sum = 0;
            foreach (var item in orderList)
            {
                if (item.HostingUnitKey == h.HostingUnitKey)
                {
                    if (item.Status == OrderStatus.Canceled || item.Status == OrderStatus.DoneDeal)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// A function that returns a list of guest requirements grouped by the required area.
        /// </summary>
        /// <returns>guest requests list sorted by the request's area. </returns>
        public List<List<GuestRequest>> GroupGuestRequestByAreas()
        {
            return (from gr in GetGuestRequestList()
                    group gr by gr.Area into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// A function that returns a list of hosting units grouped by the required area.
        /// </summary>
        /// <returns>guest requests list sorted by the hosting unit's area. </returns>
        public List<List<HostingUnit>> GroupHostingUnitsByArea()
        {
            return (from hu in GetUnitsList()
                    group hu by hu.Area into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// A function that returns a list of guest requirements grouped by the atendees.
        /// </summary>
        /// <returns>guest requests list sorted by the request's atendees. </returns>
        public List<GuestRequest> groupGuestRequestByNumOfAtendees()
        {
            List<GuestRequest> lgr = new List<GuestRequest>();
            foreach (var item in GetGuestRequestList())
            {
                var x = from newItem in GetGuestRequestList()
                        orderby newItem.Atendees
                        select newItem;
                lgr = x.ToList();
            }
            return lgr;
        }

        /// <summary>
        /// A function that returns the number of units each host has.
        /// </summary>
        /// <param name="hostID">string</param>
        /// <returns>the number of units each host has</returns>
        public int getNumOfUnits(string hostID)
        {
            int sum = 0;
            foreach (var item in getHostsList())
            {
                if(hostID==item.HostId)
                {
                    sum= GetUnitsList().Sum(x => x.Owner.HostId == item.HostId ? 1 : 0);
                }
            }
            return sum;
        }

        /// <summary>
        /// function who goes over the units list and return the hosts.
        /// </summary>
        /// <returns>hosts list</returns>
        private List<Host> getHostsList()
        {
            var hostIds = GetUnitsList().Select(x => x.Owner.HostId).Distinct().ToList();
            return hostIds.Select(x => (Host)GetHost(x).Clone()).ToList();
        }

        /// <summary>
        /// Function that deletes an order.
        /// </summary>
        /// <param name="update">Deleted order</param>
        public void DeleteOrder(Order update)
        {

        }

        /// <summary>
        /// function who arrange the guest requests by their status (grouping).
        /// </summary>
        /// <returns>guest requests list sorted by their status.</returns>
        public List<List<GuestRequest>> GroupRequestByStatus()
        {
            return (from gr in GetGuestRequestList()
                    group gr by gr.Status into g
                    select g.ToList()).ToList();
        }

        /// <summary>
        /// list of taken days.
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <returns>mark the dates are taken in the hosting unit matrix.</returns>
        public List<Tuple<DateTime, DateTime>> markTakenDatesInMatrix(HostingUnit unit)
        {
            List<Tuple<DateTime, DateTime>> res = new List<Tuple<DateTime, DateTime>>();
            var allReleventOrders = GetOrdersByUnit(unit.HostingUnitKey)
                .Where(order => order.Status == OrderStatus.DoneDeal)
                .Select(x => x.GuestRequestKey);
            return GetGuestRequestList().Where(gr => allReleventOrders.Contains(gr.GuestRequestKey))
                .Select(item => new Tuple<DateTime, DateTime>(item.EntryDate, item.ReleaseDate)).ToList();

        }

        /// <summary>
        ///  Function who returns the total number of busy days per year for one hosting unit.
        /// </summary>
        /// <param name="hostingUnit">hosting unit</param>
        /// <returns>the number of ocuupied days in a yeat at a specepic unit.</returns>
        public int GetNumberOfTakenDays(HostingUnit hostingUnit)
        {
            int counter = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (hostingUnit.Diary[i, j])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        /// <summary>
        /// A function that returns the percentage of annual occupancy for one hosting unit.
        /// </summary>
        /// <param name="UnitName">string</param>
        /// <returns>the ocuupancy precentege fot unit</returns>
        public float GetAnnualBusyPercentage(string UnitName)
        {
            double precent = 0.0, counter=0.0;
            List<HostingUnit> mylist =  GetUnitsList();
            foreach (var item in mylist)
            {
                if (UnitName == item.HostingUnitName)
                {
                    counter = GetNumberOfTakenDays(item);
                    precent = (counter / 365) * (100);
                }
            }
            return (float)precent;
        }

        /// <summary>
        /// A function that returns the percentage of annual occupancy for all the hosting unit that one host has.
        /// </summary>
        /// <param name="HostID"></param>
        /// <returns>the occupancy precentege for host</returns>
        public float GetAnnualBusyPercentageForAllUnitsForOneHost(string HostID)
        {
            List<Host> myHostList = GetHostsList();
            float sum = 0, counter = 0, precent = 0;
            foreach (var item in myHostList)
            {
                if (HostID == (item.HostId))
                {
                    List<HostingUnit> listhu = GetUnitsByHost(item.HostId);
                    foreach (var itemm in listhu)
                    {
                        counter = GetAnnualBusyPercentage(itemm.HostingUnitName);
                        sum += counter;
                    }
                    precent = (sum / 365) * (100);
                    
                }
            }
            return precent;
        }

        /// <summary>
        /// A function that returns the percentage of annual occupancy for all the hosting unit that adminisrot has.
        /// </summary>
        /// <returns>the overall occupancy precentege </returns>
        public float GetAnnualBusyPercentageForAllUnitsForTheAdministor()
        {
            float sum = 0, precent = 0;
            List<Host> listH = GetHostsList();
            foreach (var item in listH)
            {
                float counter = GetAnnualBusyPercentageForAllUnitsForOneHost(item.HostId);
                sum += counter;
            }
            precent = (sum / 365) * (100);
            return precent;
        }

        /// <summary>
        /// function who calculate the number of units that the administor has.
        /// </summary>
        /// <returns>the overall number of units.</returns>
        public int getOverallNumOfUnints()
        {
            return GetUnitsList().Count;

        }

        /// <summary>
        /// function who arrange the hosts by number of units they has (grouping).
        /// </summary>
        /// <returns>hosts list sorted by the number of units each host has.</returns>
        public List<Host> groupHostsByNumOfUnits()
        {
            List<Host> lh = new List<Host>();
            foreach (var item in getHostsList())
            {
                var x = from newItem in getHostsList()
                        orderby newItem.numOfUnits
                        select newItem;
                lh = x.ToList();
            }
            return lh;
        }

        /// <summary>
        /// function who arrange the hosting units by number of rates they has (grouping).
        /// </summary>
        /// <returns>hosting units list sorted by the number of rates each hosting unit has.</returns>
        public List<HostingUnit> groupHostingUnitsByRates()
        {
            List<HostingUnit> lhu = new List<HostingUnit>();
            foreach (var item in GetUnitsList())
            {
                var x = from newItem in GetUnitsList()
                        orderby newItem.RateStars
                        select newItem;
                lhu = x.ToList();
            }
            return lhu;
        }

        /// <summary>
        /// function who arrange the orders by their status (grouping).
        /// </summary>
        /// <returns>orders list sorted by theie status.</returns>
        public List<List<Order>> GroupOrdersByStatus()
        {
            return (from o in GetOrdersList()
                    group o by o.Status into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// function who arrange the hosting units by their type (grouping).
        /// </summary>
        /// <returns>hosting units list sorted by their type.</returns>
        public List<List<HostingUnit>> GroupHostingUnitsByType()
        {
            return (from hu in GetUnitsList()
                    group hu by hu.Type into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// function who arrange the hosting units by their owner (grouping).
        /// </summary>
        /// <returns>hosting units list sorted by their owner.</returns>
        public List<List<HostingUnit>> GroupHostingUnitsByOwner()
        {
            return (from hu in GetUnitsList()
                    group hu by hu.Owner.HostId into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// function who arrange the banks by their bank's number (grouping).
        /// </summary>
        /// <returns>banks list sorted by their bank's number.</returns>
        public List<BankBranch> GroupBanksByBankNumber()
        {
                List<BankBranch> lbb = new List<BankBranch>();
                foreach (var item in GetBankList())
                {
                    var x = from newItem in GetBankList()
                            orderby newItem.BankNumber
                            select newItem;
                    lbb = x.ToList();
                }
                return lbb;
            }
        }


    
    }

