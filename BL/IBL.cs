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

    }
}