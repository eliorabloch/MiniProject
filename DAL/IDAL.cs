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
        void addRequst(GuestRequest newRequest);
        void updateRequest(GuestRequest update);
        void addUnit(HostingUnit newUnit);
        void deleteUnit(HostingUnit delUnit);
        void updateUnit(HostingUnit update);
        void addOrder(Order newOrder);
        void updateOrder(Order update);
        void unitList(List<HostingUnit> unitsList);
        void customerList(List<GuestRequest> customersList);
        void orderList(List<Order> ordersList);
        List <string> bankList(List <BankAccount> bankLists);




    }
}
