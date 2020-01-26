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
        GuestRequest GetRequest(int id);
        void AddRequest(GuestRequest newRequest);
        void UpdateRequest(GuestRequest update);
        void DeleteRequest(GuestRequest newRequest);

        HostingUnit GetUnit(int id);
        void AddUnit(HostingUnit newUnit);//A function that adds a hosting unit
        void UpdateUnit(HostingUnit update);//A function that updates a hosting unit.
        void DeleteUnit(HostingUnit delUnit);//A function that deletes a hosting unit.
        
        /// <summary>
        /// Get the order
        /// </summary>
        /// <param name="id">the order id to get</param>
        /// <returns>the order or null if not found</returns>
        Order GetOrder(int id);

        void AddOrder(Order newOrder);//A function that adds an order to the list.
        void UpdateOrder(Order update);//Function that updates an order.
        /// <summary>
        /// Function that deletes an order
        /// </summary>
        /// <param name="update">the order to update</param>
        void DeleteOrder(Order update);

        List<Host> GetHostList();
        List<HostingUnit> GetUnitsList();
        List<GuestRequest> GetGuestRequestList();
        List<Order> GetOrdersList();
        List<BankBranch> GetBankList();
        void UpdateProfits(double days);
        void UpdateHost(Host owner);
        double GetProfits();
    }
}
