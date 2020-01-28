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
        GuestRequest GetGuestRequest(int id);

        void AddRequest(GuestRequest newGuestRequest);

        void UpdateRequest(GuestRequest updateGuestRequest);

        void DeleteRequest(GuestRequest newGuestRequest);

        HostingUnit GetHostingUnit(int id);

        void AddHostingUnit(HostingUnit newHostingUnit);

        void UpdateHostingUnit(HostingUnit updateHostingUnit);

        void DeleteHostingUnit(HostingUnit deleteHostingUnit);

        Order GetOrder(int id);

        void AddOrder(Order newOrder);

        void UpdateOrder(Order updateOrder);

        void DeleteOrder(Order deleteOrder);

        List<HostingUnit> GetHostingUnitsList();

        List<GuestRequest> GetGuestRequestList();

        List<Order> GetOrdersList();

        List<BankBranch> GetBankList();




        /// <summary>
        /// A function that accepts a date and number of vacation days and returns the list of all available accommodation units on that date.
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="amountOfDAys">Amount of dates the guest want to stay at the hostingUnit.</param>
        /// <returns>List with all the available units at some dates.</returns>
        List<HostingUnit> GetAllAvilableUnits(DateTime start, int amountOfDays);

        /// <summary>
        /// Function who checks wheter the requests are fit to some condition.
        /// </summary>
        /// <param name="condition">predicate of guest request</param>
        /// <returns>all the guest request who fit to the condition.</returns>
        List<GuestRequest> GetAllGuestRequest(Predicate<GuestRequest> condition);

        /// <summary>
        /// function who goes over the orders list and count how many orders there are for an 1 guest request.
        /// </summary>
        /// <param name="gr">guest request</param>
        /// <returns>the number of orders we have</returns>
        int GetNumOfOrders(GuestRequest guestrequest);

        /// <summary>
        /// function who calculate the number of sent orders.
        /// </summary>
        /// <param name="hu">hosting unit</param>
        /// <returns>the number of sent orders.</returns>
        int GetNumOfSentOrders(HostingUnit hostingunit);


    }
}