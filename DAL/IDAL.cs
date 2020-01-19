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
        void AddUnit(HostingUnit newUnit);
        void UpdateUnit(HostingUnit update);
        void DeleteUnit(HostingUnit delUnit);

        Order GetOrder(int id);
        void AddOrder(Order newOrder);
        void UpdateOrder(Order update);
        void DeleteOrder(Order update);

        List<Host> GetHostList();
        List<HostingUnit> GetUnitsList();
        List<GuestRequest> GetGuestRequestList();
        List<Order> GetOrdersList();
        List<BankBranch> GetBankList(); 

    }
}
