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
        // Mirror of DAL functions
        GuestRequest GetRequest(int id);
        void AddRequest(GuestRequest newRequest);//A function that adds a new hosting requirement
        void UpdateRequest(GuestRequest update);//A function that updates a hosting requirement
        void DeleteRequest(GuestRequest newRequest);//A function that deletes a new hosting requirement

        HostingUnit GetUnit(int id);
        void AddUnit(HostingUnit newUnit);//A function that adds a hosting unit
        void UpdateUnit(HostingUnit update);//A function that updates a hosting unit.
        void DeleteUnit(HostingUnit delUnit);//A function that deletes a hosting unit.

        Order GetOrder(int id);
        void AddOrder(Order newOrder);//A function that adds an order to the list.
        void UpdateOrder(Order update);//Function that updates an order.
        void DeleteOrder(Order update);//Function that deletes an order.

        List<HostingUnit> GetUnitsList();// A function that returns a hosting unit list.
        List<GuestRequest> GetGuestRequestList();// A function that returns a list of hosting requests
        List<Order> GetOrdersList();//Function that returns an order list.
        List<BankBranch> GetBankList(); //A function that returns a list of banks.



        // BL new  function
       // void GetHost(HostingUnit h);
        bool AvailableDate(HostingUnit h, GuestRequest g);
        List<HostingUnit> GetAllAvilableUnits(HostingUnit unit, DateTime start, int amountOfDAys);
        bool SendOrder(Host h, Order o);
        double AmountOfDays(DateTime start, DateTime end);
        List<Order> GetOldOrders(int amountOfDays);
        List<GuestRequest> GetAllGuestRequest(Predicate<GuestRequest> condition);
        int GetNumOfOrders(GuestRequest gr);
        int GetNumOfSentOrders(HostingUnit hu);

        List<List<GuestRequest>> GroupGuestRequestByAreas();//A function that returns a list of guest requirements grouped by the required area.
        List<List<GuestRequest>> GroupGuestRequestByNumOfAtendees();//A function that returns a customer requirements list grouped by the number of vacationers.
        List<List<Host>> GroupHostsByNumOfUnits();//A function that returns a host list grouped by the number of hosting units they hold.
        List<List<HostingUnit>> GroupHostingUnitsByArea();//A function that returns a list of hosting units grouped according to the required area.
    }
}