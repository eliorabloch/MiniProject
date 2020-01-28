using DAL;
using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Timers;



using System.Net.Mail;
namespace BL
{
    public class ImpBL : IBL
    {
        static Timer ExpiredOrdersThreads;
      
        #region singelton
        /// <summary>
        /// //Using Singleton makes sure that no new instance of the class is ever created but only one instance.
        /// </summary>
        private static readonly ImpBL instance = new ImpBL();
        public static ImpBL Instance
        {
            get { return instance; }
        }

        static IDAL dal;
        
        static ImpBL()
        {
            string TypeDAL = ConfigurationSettings.AppSettings.Get("TypeDS");
            dal = factoryDAL.GetDAL(TypeDAL);

            ExpiredOrdersThreads = new Timer(TimeSpan.FromDays(1).TotalMilliseconds);
            ExpiredOrdersThreads.Elapsed += disposeExpiredOrders;
            ExpiredOrdersThreads.Start();
        }

        #endregion

        #region Host
        
        public List<Host> GetHostsList()
        {
            return dal.GetHostList();
        }

        /// <summary>
        /// function who arrange the hosts by number of units they has (grouping).
        /// </summary>
        /// <returns>hosts list sorted by the number of units each host has.</returns>
        public List<Host> groupHostsByNumberOfUnits()
        {
            List<Host> hostsList = new List<Host>();
            foreach (var host in getHostsList())
            {
                var x = from newItem in getHostsList()
                        orderby newItem.numOfUnits
                        select newItem;
                hostsList = x.ToList();
            }
            return hostsList;
        }

        /// <summary>
        /// function who goes over the units list and return the hosts.
        /// </summary>
        /// <returns>hosts list</returns>
        private List<Host> getHostsList()
        {
            var hostIds = GetHostingUnitsList().Select(x => x.Owner.HostId).Distinct().ToList();
            return hostIds.Select(x => (Host)GetHost(x).Clone()).ToList();
        }

        public void UpdateHostInfo(Host owner, int unitKey)
        {
            var oldHost = GetHost(owner.HostId);
            if (oldHost.CollectionClearance &&
                !owner.CollectionClearance &&
                isHaveOpenOrder(unitKey))
            {
                throw new TzimerException("Collection Clearance authorization cannot be revoked when there is an open order associated with it's host", "bl");
            }
            dal.UpdateHost(owner);
        }

        #endregion 

        #region Gusets Requsts

        /// <summary>
        ///  Fanction who search for a guest requests by its key.
        /// </summary>
        /// <param name="hostingUnit">list of guest requests</param>
        /// <param name="key">unit key</param>
        /// <returns>guest request when given his request key.</returns>
        public List<GuestRequest> searchByKey(string guestRequestKey)
        {
            return GetGuestRequestList().Where(x => x.GuestRequestKey.ToString().StartsWith(guestRequestKey)).ToList();
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
                .Where(x => x.FamilyName.ToLower().StartsWith(familyName.ToLower())).ToList();
        }

        /// <summary>
        /// function who arrange the guest requests by their status (grouping).
        /// </summary>
        /// <returns>guest requests list sorted by their status.</returns>
        public List<List<GuestRequest>> GroupGuestRequestByStatus()
        {
            return (from guestRequest in GetGuestRequestList()
                    group guestRequest by guestRequest.Status into g
                    select g.ToList()).ToList();
        }

        public List<GuestRequest> GetAllGuestRequest(Predicate<GuestRequest> condition)
        {
            return GetGuestRequestList().Where(x => condition(x)).ToList();
        }

        /// <summary>
        /// A function that returns a list of guest requirements grouped by the required area.
        /// </summary>
        /// <returns>guest requests list sorted by the request's area. </returns>
        public List<List<GuestRequest>> GroupGuestRequestByAreas()
        {
            return (from guestRequest in GetGuestRequestList()
                    group guestRequest by guestRequest.Area into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// A function that returns a list of guest requirements grouped by the atendees.
        /// </summary>
        /// <returns>guest requests list sorted by the request's atendees. </returns>
        public List<GuestRequest> groupGuestRequestByNumberOfAtendees()
        {
            List<GuestRequest> guestRequestList = new List<GuestRequest>();
            foreach (var request in GetGuestRequestList())
            {
                var x = from newItem in GetGuestRequestList()
                        orderby newItem.Atendees
                        select newItem;
                guestRequestList = x.ToList();
            }
            return guestRequestList;
        }

        public GuestRequest GetGuestRequest(int id)
        {
            return getGuestRequestIfExists(id);
        }

        /// <summary>
        /// function who match between request to unit.
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <returns>guest requests list</returns>
        public List<GuestRequest> matchRequestToUnit(HostingUnit hostingUnit, string subAreaFilter, string attendantsAmount)
        {
            return GetGuestRequestList().Where(guestRequestItem => checkIfUnitMatchToRequest(hostingUnit, guestRequestItem, subAreaFilter, attendantsAmount) != null).ToList();
        }

        /// <summary>
        /// function who check the match between unit to request.
        /// </summary>
        /// <param name="hu">hosting unit</param>
        /// <param name="gr">guest request</param>
        /// <returns>the guest request if there is a match.</returns>
        public GuestRequest checkIfUnitMatchToRequest(HostingUnit hostingUnit, GuestRequest guestRequest, string subAreaFilter, string attendantsAmount)
        {
            if (GetOrdersList().Any(order => order.GuestRequestKey == guestRequest.GuestRequestKey && order.HostingUnitKey == hostingUnit.HostingUnitKey))
            {
                return null;
            }

            int attendants;
            var filterAttendants = int.TryParse(attendantsAmount, out attendants);
            bool enoughAttendees = filterAttendants ? int.Parse(guestRequest.Children) + int.Parse(guestRequest.Adults) == attendants : true;
            if (
                hostingUnit.Area == guestRequest.Area
                && hostingUnit.Type == guestRequest.Type
                && isDatesAvilable(hostingUnit, guestRequest.EntryDate, guestRequest.ReleaseDate)
                && enoughAttendees
                && guestRequest.SubArea.ToLower().StartsWith(subAreaFilter.ToLower())
                && isMatchRequirment(hostingUnit.Pool, guestRequest.Pool)
                && isMatchRequirment(hostingUnit.Jacuzz, guestRequest.Jacuzzi)
                && isMatchRequirment(hostingUnit.Garden, guestRequest.Garden)
                && isMatchRequirment(hostingUnit.ChildrensAttractions, guestRequest.ChildrensAttractions)
                && isMatchRequirment(hostingUnit.breakfastIncluded, guestRequest.breakfastIncluded)
                && isMatchRequirment(hostingUnit.FreeParking, guestRequest.FreeParking)
                && isMatchRequirment(hostingUnit.RoomService, guestRequest.RoomService)
                )
            {
                return guestRequest;
            }

            return null;
        }
     
        public double GetProfits()
        {
            return dal.GetProfits();
        }

        /// <summary>
        /// function who matching between property to unit.
        /// </summary>
        /// <param name="hasOption">bool</param>
        /// <param name="requrement">options</param>
        /// <returns>true if there is a match and false if not.</returns>
        bool isMatchRequirment(bool hasOption, Options requrement)
        {
            return !(!hasOption && requrement == Options.necessary);
        }

        /// <summary>
        /// function who arrange the guest requests by their status (grouping).
        /// </summary>
        /// <returns>guest requests list sorted by theie status.</returns>
        public List<List<GuestRequest>> GroupRequesteByStatus()
        {
            return (from guestRequest in GetGuestRequestList()
                    group guestRequest by guestRequest.Status into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// function who give me host by his id number.
        /// </summary>
        /// <param name="hostId">string</param>
        /// <returns>host</returns>
        public Host GetHost(string hostId)
        {
            var hostingUnit = GetHostingUnitsList().FirstOrDefault(x => x.Owner.HostId == hostId);
            if (hostingUnit != null)
            {
                return hostingUnit.Owner;
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
            dal.AddGuestRequest(newRequest);
        }

        /// <summary>
        /// A function that updates a hosting requirement.
        /// </summary>
        /// <param name="update">Updating request.</param>
        public void UpdateRequest(GuestRequest updatedRequest)
        {
            validGuestRequest(updatedRequest);

            GuestRequest oldRequest = getGuestRequestIfExists(updatedRequest.GuestRequestKey);

            if ((updatedRequest.Status != RequestStatus.ClosedDeal && oldRequest.Status == RequestStatus.ClosedDeal)
                ||
                (updatedRequest.Status != RequestStatus.ExpiredRequest && oldRequest.Status == RequestStatus.ExpiredRequest))
            {
                throw new TzimerException($"Cannot update a closed request, Request ID: {updatedRequest.GuestRequestKey}", "bl");
            }

            dal.UpdateGuestRequest(updatedRequest);
        }

        /// <summary>
        /// A delegate function that accepts any guest request and checks by its ID whether it already exists, if it does not throw an exception, else returns the request.
        /// </summary>
        static Func<int, GuestRequest> getGuestRequestIfExists = delegate (int guestRequestID)
        {
            var oldRequest = dal.GetGuestRequest(guestRequestID);
            if (oldRequest == null)
            {
                throw new TzimerException($"Cannot find Requst with ID: {guestRequestID}", "bl");
            }
            return oldRequest;
        };

        /// <summary>
        /// A function that deletes a new hosting requirement
        /// </summary>
        /// <param name="newRequest">Deleted request.</param>
        public void DeleteRequest(GuestRequest deleteRequest)
        {
            getGuestRequestIfExists(deleteRequest.GuestRequestKey);
            if (isHaveDoneDealOrder(deleteRequest))
            {
                throw new TzimerException("Cannot delete a request with a done deal order.", "bl");
            }
            List<Order> releatedOrders = getOrdersByRequestNotDoneDeal(deleteRequest.GuestRequestKey);
            foreach (var order in releatedOrders)
            {
                DeleteOrder(order);
            }
            dal.DeleteGuestRequest(deleteRequest);
        }

        private List<Order> getOrdersByRequestNotDoneDeal(int guestRequestKey)
        {
            return GetOrdersList().Where(x => x.GuestRequestKey == guestRequestKey && x.Status != OrderStatus.DoneDeal).ToList();
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

        /// <summary>
        /// function who goes to the DAL and give me the uest request list.
        /// </summary>
        /// <returns>guest requests lits</returns>
        public List<GuestRequest> GetGuestRequestList()
        {
            return dal.GetGuestRequestList();
        }

        #endregion

        #region Hosting Units

        /// <summary>
        /// function who arrange the hosting units by number of rates they has (grouping).
        /// </summary>
        /// <returns>hosting units list sorted by the number of rates each hosting unit has.</returns>
        public List<HostingUnit> groupHostingUnitsByRates()
        {
            List<HostingUnit> hostingUnitsList = new List<HostingUnit>();
            foreach (var hostingUnit in GetHostingUnitsList())
            {
                var x = from newItem in GetHostingUnitsList()
                        orderby newItem.RateStars
                        select newItem;
                hostingUnitsList = x.ToList();
            }
            return hostingUnitsList;
        }

        /// <summary>
        /// function who get the all units one host has.
        /// </summary>
        /// <param name="hostId">string</param>
        /// <returns>hosting units list</returns>
        public List<HostingUnit> GetHostingUnitsByHost(string hostId)
        {
            return GetHostingUnitsList().Where(x => x.Owner.HostId == hostId).ToList();
        }

        /// <summary>
        /// function who arrange the hosting units by their type (grouping).
        /// </summary>
        /// <returns>hosting units list sorted by their type.</returns>
        public List<List<HostingUnit>> GroupHostingUnitsByType()
        {
            return (from hostingUnit in GetHostingUnitsList()
                    group hostingUnit by hostingUnit.Type into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// function who arrange the hosting units by their owner (grouping).
        /// </summary>
        /// <returns>hosting units list sorted by their owner.</returns>
        public List<List<HostingUnit>> GroupHostingUnitsByOwner()
        {
            return (from hostingUnit in GetHostingUnitsList()
                    group hostingUnit by hostingUnit.Owner.HostId into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// A function that returns a list of hosting units grouped by the required area.
        /// </summary>
        /// <returns>guest requests list sorted by the hosting unit's area. </returns>
        public List<List<HostingUnit>> GroupHostingUnitsByArea()
        {
            return (from hostingUnit in GetHostingUnitsList()
                    group hostingUnit by hostingUnit.Area into g
                    select g.ToList()).ToList();

        }

        /// <summary>
        /// Fanction who search for a hosting units by its key.
        /// </summary>
        /// <param name="hostingUnit">hosting unit</param>
        /// <param name="key">int</param>
        /// <returns>hosting units when given his unit key.</returns>
        public HostingUnit searchByKey(List<HostingUnit> hostingUnitsList, int hostingUnitKey = -1)
        {
            foreach (var hostingUnit in hostingUnitsList)
            {
                if (hostingUnit.HostingUnitKey == hostingUnitKey)
                {
                    return hostingUnit;
                }
            }
            throw new TzimerException($"Sorry,cant find a request with the key{hostingUnitKey}", "bl");
        }

        public List<HostingUnit> GetAllAvilableUnits(DateTime start, int amountOfDays)
        {
            DateTime end = start.AddDays(amountOfDays);
            return GetHostingUnitsList().Where(x => isDatesAvilable(x, start, end)).ToList();
        }

        /// <summary>
        /// Fanction who search for a hosting units by its name.
        /// </summary>
        /// <param name="hostingUnit">hosting unit</param>
        /// <param name="key">int</param>
        /// <returns>hosting units when given his unit name.</returns>
        public List<HostingUnit> searchByName(List<HostingUnit> HostingUnit, string HostingUnitName)
        {
            bool ifExist = false;
            List<HostingUnit> HostingUnitNames = new List<HostingUnit>();
            foreach (var item in HostingUnit)
            {
                if (item.HostingUnitName == HostingUnitName)
                {
                    HostingUnitNames.Add(item);
                    ifExist = true;
                }

            }
            if (ifExist)
            {
                return HostingUnitNames;
            }

            else
            {
                throw new TzimerException($"Sorry,cant find a request with the name:{HostingUnitName}", "bl");
            }
        }

        /// <summary>
        /// A delegate function that accepts any hosting unit and checks by its ID whether it already exists, if it does not throw an exception, else returns the unit.
        /// </summary>
        static Func<int, HostingUnit> getHostingUnitsIfExists = delegate (int id)
        {
            var oldHostingUnit = dal.GetHostingUnit(id);
            if (oldHostingUnit == null)
            {
                throw new TzimerException($"Cannot find Unit with ID: {id}", "bl");
            }
            return oldHostingUnit;
        };

        public HostingUnit GetHostingUnit(int id)
        {
            return getHostingUnitsIfExists(id);
        }

        /// <summary>
        /// A function that adds a hosting unit.
        /// </summary>
        /// <param name="update">Updating hostingunit.</param>
        public void AddHostingUnit(HostingUnit newHostingUnit)
        {
            validHostingUnit(newHostingUnit);
            dal.AddHostingUnit(newHostingUnit);
        }

        /// <summary>
        /// A function that updates a hosting unit.
        /// </summary>
        /// <param name="delUnit">Deleted request.</param>
        public void UpdateHostingUnit(HostingUnit updatedHostingUnit)
        {
            getHostingUnitsIfExists(updatedHostingUnit.HostingUnitKey);
            dal.UpdateHostingUnit(updatedHostingUnit);
        }

        /// <summary>
        /// A function that deletes a hosting unit.
        /// </summary>
        /// <param name="delUnit">Deleted hostingunit</param>
        public void DeleteHostingUnit(HostingUnit delHostingUnit)
        {
            getHostingUnitsIfExists(delHostingUnit.HostingUnitKey);
            if (isHaveOpenOrder(delHostingUnit.HostingUnitKey))
            {
                throw new TzimerException("Cannot delete Host Unit that has active deals", "bl");
            }
            dal.DeleteHostingUnit(delHostingUnit);
        }

        /// <summary>
        ///A function that goes through the order list and checks for an open order. 
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <returns>if there is an open order</returns>
        private static bool isHaveOpenOrder(int HostingUnitKey)
        {
            return dal.GetOrdersList().Any(x => x.HostingUnitKey == HostingUnitKey && (x.Status == OrderStatus.NotHandled || x.Status == OrderStatus.SentMail));
        }

        /// <summary>
        ///A function that goes through the order list and checks for an open order. 
        /// </summary>
        /// <param name="req">Guest Request</param>
        /// <returns>if there is an open order</returns>
        private static bool isHaveDoneDealOrder(GuestRequest req)
        {
            return dal.GetOrdersList().Any(x => x.GuestRequestKey == req.GuestRequestKey && x.Status == OrderStatus.DoneDeal);
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
        public List<HostingUnit> GetHostingUnitsList()
        {
            return dal.GetHostingUnitsList();
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
        /// function who goes to the DAL and give me the order list.
        /// </summary>
        /// <returns>orders lits</returns>
        public List<Order> GetOrdersList()
        {
            return dal.GetOrdersList();
        }

        /// <summary>
        /// function who arrange the orders by their unitws key (grouping).
        /// </summary>
        /// <returns>orders list sorted by their unit.</returns>
        public List<List<Order>> GroupOrdersByHostingUnit()
        {
            return (from order in GetOrdersList()
                    group order by order.HostingUnitKey into g
                    select g.ToList()).ToList();
        }

        public List<Order> GetOldOrders(int amountOfDays)
        {
            return GetOrdersList().Where(x => isOldOrder(x, amountOfDays)).ToList();
        }

        /// <summary>
        /// A delegate function that accepts any order and checks by its ID whether it already exists, if it does not throw an exception, else returns the order.
        /// </summary>
        static Func<int, Order> getOrderIfExists = delegate (int orderID)
        {
            var oldOrder = dal.GetOrder(orderID);
            if (oldOrder == null)
            {
                throw new TzimerException($"Cannot find Order with ID: {orderID}", "bl");
            }
            return oldOrder;
        };

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
        /// function who arrange the orders by their status (grouping).
        /// </summary>
        /// <returns>orders list sorted by theie status.</returns>
        public List<List<Order>> GroupOrdersByStatus()
        {
            return (from order in GetOrdersList()
                    group order by order.Status into g
                    select g.ToList()).ToList();

        }

        public Order GetOrder(int orderID)
        {
            return getOrderIfExists(orderID);
        }

        /// <summary>
        /// A function that adds an order to the list.
        /// </summary>
        /// <param name="newOrder">Adding order</param>
        public void AddOrder(Order newOrder)
        {
            var request = getGuestRequestIfExists(newOrder.GuestRequestKey);
            var hostingUnit = getHostingUnitsIfExists(newOrder.HostingUnitKey);
            if (!AvailableDate(hostingUnit, request))
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
            var request = getGuestRequestIfExists(updatedOrder.GuestRequestKey);
            var hostingUnit = getHostingUnitsIfExists(updatedOrder.HostingUnitKey);
            if (oldOrder.Status == OrderStatus.Canceled || oldOrder.Status == OrderStatus.DoneDeal)
            {
                throw new TzimerException("Sorry, this order already closed", "bl");
            }
            if (updatedOrder.Status == OrderStatus.DoneDeal)
            {
                var totalDays = (request.ReleaseDate - request.EntryDate).TotalDays;
                dal.UpdateProfits(totalDays);
                updateDatesAvilable(hostingUnit, request);
                UpdateHostingUnit(hostingUnit);
                cancelAllOtherOrders(updatedOrder);
                request.Status = RequestStatus.ClosedDeal;
            }
            if (updatedOrder.Status == OrderStatus.Canceled)
            {
                request.Status = RequestStatus.ExpiredRequest;
            }
            if (updatedOrder.Status == OrderStatus.NotHandled)
            {
                request.Status = RequestStatus.Open;
            }
            UpdateRequest(request);
            dal.UpdateOrder(updatedOrder);
        }

        /// <summary>
        /// Fanction who search for a orders by its key.
        /// </summary>
        /// <param name="order">order</param>
        /// <param name="key">int</param>
        /// <returns>order when given his order key.</returns>
        public Order searchByKey(List<Order> order, int orderKey = -1)
        {
            foreach (var Order in order)
            {
                if (Order.OrderKey == orderKey)
                {
                    return Order;
                }
            }
            return null;
        }

        #endregion

        #region Bank Branch

        /// <summary>
        /// function who goes to the DAL and give me the bank list.
        /// </summary>
        /// <returns>bank branchs lits</returns>
        public List<BankBranch> GetBankList()
        {
            return dal.GetBankList();
        }

        /// <summary>
        /// function who arrange the banks by their bank's number (grouping).
        /// </summary>
        /// <returns>banks list sorted by their bank's number.</returns>
        public List<BankBranch> GroupBanksByBankNumber()
        {
            List<BankBranch> bankBranchesList = new List<BankBranch>();
            foreach (var bank in GetBankList())
            {
                var x = from newItem in GetBankList()
                        orderby newItem.BankNumber
                        select newItem;
                bankBranchesList = x.ToList();
            }
            return bankBranchesList;
        }

        #endregion

        #region More

        private static void disposeExpiredOrders(object sender, ElapsedEventArgs e)
        {
            Instance.GetOldOrders(30).Where(x => x.Status == OrderStatus.SentMail).Select(x => {
                x.Status = OrderStatus.Canceled;
                Instance.UpdateOrder(x);
                return x;
            });
        }

        /// <summary>
        /// A function that checks whether an order can be sent to a customer. Only if the client has signed a host bank authorization form can he send an order.
        /// </summary>
        /// <param name="h">host</param>
        /// <param name="o">order</param>
        /// <param name="hu">hosting unit</param>
        /// <returns>if the hostingUnit fit to guest requst, send mail.</returns>
        public bool SendOrder(Host host, Order order, HostingUnit hostingunit)
        {
            if (host.CollectionClearance)
            {
                MailMessage mail = new MailMessage();
                GuestRequest gr = GetGuestRequest(order.GuestRequestKey);
                // mail.To.Add(gr.MailAddress);

                mail.To.Add("eliora.bloch@gmail.com");

                mail.From = new MailAddress("VacationModePlan@gmail.com");
                mail.Body = $"Dear {gr.PrivateName}  {gr.FamilyName}, <br><br>" +
                    $"We have found a unit that matches your request number {order.GuestRequestKey}.<br>" +
                    $"The unit is called {hostingunit.HostingUnitName}.<br>" +
                    $"You may contact the units host named {host.PrivateName } {host.FamilyName} through this email address: {host.MailAddress}, or by calling this number: {host.PhoneNumber}.<br>" +
                    $"We are looking forward to closing a deal with you.<br><br>" +
                    $"Yours, VacationMode";

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("VacationModePlan@gmail.com", "vac123456");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                order.Status = OrderStatus.SentMail;
                UpdateOrder(order);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static double AmountOfDays(DateTime start, DateTime end)
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
        public bool AvailableDate(HostingUnit hostingunit, GuestRequest guestrequest)
        {
            return isDatesAvilable(hostingunit, guestrequest.EntryDate, guestrequest.ReleaseDate);
        }

        bool availableDate(HostingUnit hostingunit, DateTime start, int amountOfDays)
        {
            DateTime end = start.AddDays(amountOfDays);
            return isDatesAvilable(hostingunit, start, end);
        }

        /// <summary>
        /// function who update the order status and cancel the other orders who sent to the guest.
        /// </summary>
        /// <param name="order">order</param>
        static void cancelAllOtherOrders(Order order)
        {
            dal.GetOrdersList().ForEach(Order =>
            {
                if (Order.GuestRequestKey == order.GuestRequestKey && Order.OrderKey != order.OrderKey)
                {
                    Order.Status = OrderStatus.Canceled;
                    dal.UpdateOrder(Order);
                }
            });
        }

        /// <summary>
        /// If a vacant unit is on a particular date and the guest wants to be in this unit - the matrix will change the days in the unit to be occupied.
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <param name="req">guest request</param>
        void updateDatesAvilable(HostingUnit hostingunit, GuestRequest guestrequest)
        {
            DateTime tempDate = guestrequest.EntryDate;
            while (tempDate < guestrequest.ReleaseDate)
            {
                hostingunit.Diary[tempDate.Month - 1, tempDate.Day - 1] = true;
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
        bool isDatesAvilable(HostingUnit hostingunit, DateTime start, DateTime end)
        {
            DateTime tempDate = start;
            while (tempDate < end)
            {
                if (hostingunit.Diary[tempDate.Month - 1, tempDate.Day - 1])
                {
                    return false;
                }

                tempDate = tempDate.AddDays(1);
            }
            return true;
        }

        /// <summary>
        /// A function that returns the number of units each host has.
        /// </summary>
        /// <param name="hostID">string</param>
        /// <returns>the number of units each host has</returns>
        public int getNumOfUnits(string hostID)
        {
            int NumOfUnits = 0;
            foreach (var host in getHostsList())
            {
                if (hostID == host.HostId)
                {
                    NumOfUnits = GetHostingUnitsList().Sum(x => x.Owner.HostId == host.HostId ? 1 : 0);
                }
            }
            return NumOfUnits;
        }

        /// <summary>
        /// Function that deletes an order.
        /// </summary>
        /// <param name="update">Deleted order</param>
        public void DeleteOrder(Order updateorder)
        {

        }

        /// <summary>
        /// list of taken days.
        /// </summary>
        /// <param name="unit">hosting unit</param>
        /// <returns>mark the dates are taken in the hosting unit matrix.</returns>
        public List<Tuple<DateTime, DateTime>> markTakenDatesInMatrix(HostingUnit hostingunit)
        {
            List<Tuple<DateTime, DateTime>> res = new List<Tuple<DateTime, DateTime>>();
            var allReleventOrders = GetOrdersByUnit(hostingunit.HostingUnitKey)
                .Where(order => order.Status == OrderStatus.DoneDeal)
                .Select(x => x.GuestRequestKey);
            return GetGuestRequestList().Where(guestrequest => allReleventOrders.Contains(guestrequest.GuestRequestKey))
                .Select(item => new Tuple<DateTime, DateTime>(item.EntryDate, item.ReleaseDate)).ToList();

        }

        /// <summary>
        ///  Function who returns the total number of busy days per year for one hosting unit.
        /// </summary>
        /// <param name="hostingUnit">hosting unit</param>
        /// <returns>the number of ocuupied days in a yeat at a specepic unit.</returns>
        public int GetNumberOfTakenDays(HostingUnit hostingUnit)
        {
            int NumberOfTakenDays = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (hostingUnit.Diary[i, j])
                    {
                        NumberOfTakenDays++;
                    }
                }
            }
            return NumberOfTakenDays;
        }

        /// <summary>
        /// A function that returns the percentage of annual occupancy for one hosting unit.
        /// </summary>
        /// <param name="UnitName">string</param>
        /// <returns>the ocuupancy precentege fot unit</returns>
        public float GetAnnualBusyPercentage(string hostingUnitName)
        {
            double precentAnnualBusy = 0.0, counterAnnualBusy = 0.0;
            List<HostingUnit> hostnigUnitsList = GetHostingUnitsList();
            foreach (var hostnigUnit in hostnigUnitsList)
            {
                if (hostingUnitName == hostnigUnit.HostingUnitName)
                {
                    counterAnnualBusy = GetNumberOfTakenDays(hostnigUnit);
                    precentAnnualBusy = (counterAnnualBusy / 365) * (100);
                }
            }
            return (float)precentAnnualBusy;
        }

        /// <summary>
        /// A function that returns the percentage of annual occupancy for all the hosting unit that one host has.
        /// </summary>
        /// <param name="HostID"></param>
        /// <returns>the occupancy precentege for host</returns>
        public float GetAnnualBusyPercentageForAllUnitsForOneHost(string HostID)
        {
            List<Host> HostList = GetHostsList();
            float sumAnnualBusy = 0, counterAnnualBusy = 0, precentAnnualBusy = 0;
            foreach (var host in HostList)
            {
                if (HostID == (host.HostId))
                {
                    List<HostingUnit> hostingUnitsList = GetHostingUnitsByHost(host.HostId);
                    foreach (var hostingunit in hostingUnitsList)
                    {
                        counterAnnualBusy = GetAnnualBusyPercentage(hostingunit.HostingUnitName);
                        sumAnnualBusy += counterAnnualBusy;
                    }
                    precentAnnualBusy = (sumAnnualBusy / 365) * (100);

                }
            }
            return precentAnnualBusy;
        }

        /// <summary>
        /// A function that returns the percentage of annual occupancy for all the hosting unit that adminisrot has.
        /// </summary>
        /// <returns>the overall occupancy precentege </returns>
        public float GetAnnualBusyPercentageForAllUnitsForTheAdministor()
        {
            float sumAnnualBusy = 0, precentAnnualBusy = 0;
            List<Host> hostsList = GetHostsList();
            foreach (var host in hostsList)
            {
                float counter = GetAnnualBusyPercentageForAllUnitsForOneHost(host.HostId);
                sumAnnualBusy += counter;
            }
            precentAnnualBusy = (sumAnnualBusy / 365) * (100);
            return precentAnnualBusy;
        }

        /// <summary>
        /// function who calculate the number of units that the administor has.
        /// </summary>
        /// <returns>the overall number of units.</returns>
        public int getOverallNumOfUnints()
        {
            return GetHostingUnitsList().Count;
        }
      
        /// <summary>
        /// function who calculate the number of sent orders.
        /// </summary>
        /// <param name="hu">hosting unit</param>
        /// <returns>the number of sent orders.</returns>
        public int GetNumOfSentOrders(HostingUnit hostingunit)
        {
            return GetOrdersList().Where(x => x.HostingUnitKey == hostingunit.HostingUnitKey &&
            (x.Status == OrderStatus.SentMail || x.Status == OrderStatus.DoneDeal)).Count();
        }

        public int GetNumOfOrders(GuestRequest guestrequest)
        {
            return GetOrdersList().Where(x => x.GuestRequestKey == guestrequest.GuestRequestKey).Count();
        }

        /// <summary>
        /// A function that goes through the order list and checks for each unit how many orders it has closed.
        /// </summary>
        /// <param name="h">hosting unit</param>
        /// <param name="orderList">list of orders</param>
        /// <returns>the amount of cloesed order for each unit.</returns>
        int amountOfOrders(HostingUnit hostingunit, List<Order> orderList)
        {
            int sumOfOrders = 0;
            foreach (var order in orderList)
            {
                if (order.HostingUnitKey == hostingunit.HostingUnitKey)
                {
                    if (order.Status == OrderStatus.Canceled || order.Status == OrderStatus.DoneDeal)
                    {
                        sumOfOrders++;
                    }
                }
            }
            return sumOfOrders;
        }

        /// <summary>
        /// function who check if more then 30 days were pass from the date the mail send till now, if so- update the status.
        /// </summary>
        /// <param name="updatedOrderStatus">order</param>
        public static void checkAndChangeStatusOrder()
        {
            if (Convert.ToDateTime(Configuration.Date) != DateTime.Now)
            {
                Configuration.Date = DateTime.Now.ToString("yyyy/M/dd ");

                foreach (var updatedOrderStatus in dal.GetOrdersList())
                {
                    if ((int)AmountOfDays(updatedOrderStatus.OrderDate, DateTime.Now) > 30)
                    {
                        updatedOrderStatus.Status = OrderStatus.Canceled;
                    }
                    dal.UpdateOrder(updatedOrderStatus);
                }
            }
        }

        #endregion
    }
}