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
        /// <summary>
        /// function who add request
        /// </summary>
        /// <param name="newRequest">guest reqest</param>
        void AddGuestRequest(GuestRequest newGuestRequest);
        /// <summary>
        /// function who update request
        /// </summary>
        /// <param name="updatedRequest">guest request</param>
        void UpdateGuestRequest(GuestRequest updateGuestRequest);
        /// <summary>
        /// function who delete an request
        /// </summary>
        /// <param name="newRequest">guest request</param>
        void DeleteGuestRequest(GuestRequest newGuestRequest);

        HostingUnit GetHostingUnit(int id);
        /// <summary>
        /// function who adding hosting unit
        /// </summary>
        /// <param name="newUnit">HostingUnit</param>
        void AddHostingUnit(HostingUnit newHostingUnit);
        /// <summary>
        /// function who update hosting unit
        /// </summary>
        /// <param name="updatedUnit">hosting unit</param>
        void UpdateHostingUnit(HostingUnit updateHostingUnit);
        /// <summary>
        /// function who delete an unit
        /// </summary>
        /// <param name="delUnit">hosting unit</param>
        void DeleteHostingUnit(HostingUnit deleteHostingUnit);

        /// <summary>
        /// Get the order
        /// </summary>
        /// <param name="id">the order id to get</param>
        /// <returns>the order or null if not found</returns>
        Order GetOrder(int id);

        /// <summary>
        /// function who adding order
        /// </summary>
        /// <param name="newOrder">order</param>
        void AddOrder(Order newOrder);
        /// <summary>
        /// function who update the order
        /// </summary>
        /// <param name="updatedOrder">order</param>
        void UpdateOrder(Order update);
        /// <summary>
        /// Function that deletes an order
        /// </summary>
        /// <param name="update">the order to delete</param>
        void DeleteOrder(Order update);

        /// <summary>
        /// Quick reboot of host list.
        /// </summary>
        /// <returns></returns>
        List<Host> GetHostList();
        /// <summary>
        /// Quick reboot of hosting units list.
        /// </summary>
        /// <returns></returns>
        List<HostingUnit> GetHostingUnitsList();
        /// <summary>
        /// Quick reboot of guest request list.
        /// </summary>
        /// <returns></returns>
        List<GuestRequest> GetGuestRequestList();
        /// <summary>
        /// Quick reboot of orders list.
        /// </summary>
        /// <returns></returns>
        List<Order> GetOrdersList();
        /// <summary>
        /// Quick reboot of bank list.
        /// </summary>
        /// <returns></returns>
        List<BankBranch> GetBankList();


        /// <summary>
        /// function who update the ptofits
        /// </summary>
        /// <param name="days">double</param>
        void UpdateProfits(double days);
        /// <summary>
        /// function who make a relevante hosts list
        /// </summary>
        /// <param name="owner">host</param>
        void UpdateHost(Host owner);
        /// <summary>
        /// function who show us the prifits
        /// </summary>
        /// <returns></returns>
        double GetProfits();
    }
}