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
        GuestRequest GetGuestRequest(int id);
        void AddGuestRequest(GuestRequest newGuestRequest);
        void UpdateGuestRequest(GuestRequest updateGuestRequest);
        void DeleteGuestRequest(GuestRequest newGuestRequest);

        HostingUnit GetHostingUnit(int id);
        void AddHostingUnit(HostingUnit newHostingUnit);
        void UpdateHostingUnit(HostingUnit updateHostingUnit);
        void DeleteHostingUnit(HostingUnit deleteHostingUnit);
        
        /// <summary>
        /// Get the order
        /// </summary>
        /// <param name="id">the order id to get</param>
        /// <returns>the order or null if not found</returns>
        Order GetOrder(int id);

        void AddOrder(Order newOrder);
        void UpdateOrder(Order update);
        /// <summary>
        /// Function that deletes an order
        /// </summary>
        /// <param name="update">the order to update</param>
        void DeleteOrder(Order update);

        List<Host> GetHostList();
        List<HostingUnit> GetHostingUnitsList();
        List<GuestRequest> GetGuestRequestList();
        List<Order> GetOrdersList();
        List<BankBranch> GetBankList();
        void UpdateProfits(double days);
        void UpdateHost(Host owner);
        double GetProfits();
    }
}
