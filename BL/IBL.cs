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
        List<List<GuestRequest>> GroupRequestByStatus();// Function who sort the geust requests by their status.

        // BL new  function
        float GetAnnualBusyPercentage(string UnitName);
        bool AvailableDate(HostingUnit h, GuestRequest g);//A function that makes sure the booked dates are free in the unit we placed the order.
        List<HostingUnit> GetAllAvilableUnits( DateTime start, int amountOfDAys);//A function that accepts a date and number of vacation days and returns the list of all available accommodation units on that date.
        bool SendOrder(Host h, Order o);//A function that checks whether an order can be sent to a customer. Only if the client has signed a host bank authorization form can he send an order.
        double AmountOfDays(DateTime start, DateTime end);//A function that accepts two dates and checks the time difference between them. If the function has only received one date, it will check how much time has passed from that date until now.
        List<Order> GetOldOrders(int amountOfDays);
        List<GuestRequest> GetAllGuestRequest(Predicate<GuestRequest> condition);//A function that can return all customer requirements that fit a particular condition.
        int GetNumOfOrders(GuestRequest gr);//A function that accepts customer demand and returns the number of orders sent to it.
        int GetNumOfSentOrders(HostingUnit hu);//A function that accepts a hosting unit and returns the number of invitations sent / the number of orders successfully closed for this unit through the site.
        HostingUnit searchByKey(List<HostingUnit> hostingUnit, int key = -1);// Fanction who search for a hosting units by its key.
        List<HostingUnit> searchByName(List<HostingUnit> HostingUnit, string Name);//Function who search for a hosting unit by its name.
        Order searchByKey(List<Order> order, int key = -1);// Fanction who search for a orders by its key.
        GuestRequest checkIfUnitMatchToRequest(HostingUnit hu, GuestRequest gr);// Check if hosting unit is fit to guest request.
        List<Tuple<DateTime, DateTime>> markTakenDatesInMatrix(HostingUnit unit);//list of taken days;
        List<List<GuestRequest>> GroupGuestRequestByAreas();//A function that returns a list of guest requirements grouped by the required area.
        List<List<GuestRequest>> GroupGuestRequestByNumOfAtendees();//A function that returns a customer requirements list grouped by the number of vacationers.
        List<List<Host>> GroupHostsByNumOfUnits();//A function that returns a host list grouped by the number of hosting units they hold.
        List<List<HostingUnit>> GroupHostingUnitsByArea();//A function that returns a list of hosting units grouped according to the required area.
    }
}