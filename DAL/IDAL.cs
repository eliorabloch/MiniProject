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
        void AddRequest(GuestRequest newRequest);//A function that adds a new hosting requirement
        void UpdateRequest(GuestRequest update);//A function that updates a hosting requirement
        void DeleteRequest(GuestRequest newRequest);//A function that deletes a new hosting requirement

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

        List<Host> GetHostList();// A function that returns a hosts list.
        List<HostingUnit> GetUnitsList();// A function that returns a hosting unit list.
        List<GuestRequest> GetGuestRequestList();// A function that returns a list of hosting requests
        List<Order> GetOrdersList();//Function that returns an order list.
        List<BankBranch> GetBankList(); //A function that returns a list of banks.

    }
}
