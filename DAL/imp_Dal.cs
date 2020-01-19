using BE;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class imp_Dal : IDAL
    {

        #region singleton
        
        /// <summary>
        /// Using Singleton makes sure that no new instance of the class is ever created but only one instance.
        /// </summary>
        private static imp_Dal instance = null;

        public static imp_Dal getInstance()
        {
            if (instance == null)
            {
                instance = new imp_Dal();
            }
            return instance;
        }
        #endregion


        private imp_Dal()
        {
            DataSource.Init();
        }//constractor

        #region Guest Requst

        public List<GuestRequest> GetGuestRequestList()
        {
            return (from gr in DataSource.requestList
                   select (GuestRequest)gr.Clone()).ToList();
        }

        public GuestRequest GetRequest(int id)
        {
            return (GuestRequest)GetGuestRequestList().FirstOrDefault(x=>x.GuestRequestKey == id)?.Clone();
        }

        /// <summary>
        /// function who add request
        /// </summary>
        /// <param name="newRequest">guest reqest</param>
        public void AddRequest(GuestRequest newRequest)
        {
            if(GetGuestRequestList().Any(x => x.GuestRequestKey == newRequest.GuestRequestKey))
            {
                throw new TzimerException($"Guest Request with the ID: {newRequest.GuestRequestKey} - already exists!", "dal");
            }
            newRequest.GuestRequestKey = Configuration.GuestRequestId++;
            DataSource.requestList.Add((GuestRequest)newRequest.Clone());
        }

        /// <summary>
        /// function who update request
        /// </summary>
        /// <param name="updatedRequest">guest request</param>
        public void UpdateRequest(GuestRequest updatedRequest)
        {
            DataSource.requestList.ForEach(x =>
            {
                if (x.GuestRequestKey == updatedRequest.GuestRequestKey)
                {
                    x.Status = updatedRequest.Status;
                }
            });

        }
     
        /// <summary>
        /// function who delete an unit
        /// </summary>
        /// <param name="newRequest">guest request</param>
        public void DeleteRequest(GuestRequest newRequest)
        {
            DataSource.requestList.RemoveAll(x => x.GuestRequestKey == newRequest.GuestRequestKey);
        }

        #endregion

        #region Hosting Units

        public List<HostingUnit> GetUnitsList()
        {
            return (from gr in DataSource.unitList
                    select (HostingUnit)gr.Clone()).ToList();
        }

        public List<Host> GetHostList()
        {
            return DataSource.unitList.Select(h=> (Host)h.Owner.Clone()).Distinct().ToList();

        }

        public HostingUnit GetUnit(int id)
        {
            return (HostingUnit)DataSource.unitList.FirstOrDefault(x => x.HostingUnitKey == id)?.Clone();
        }
    
        /// <summary>
        /// function who adding hosting unit
        /// </summary>
        /// <param name="newUnit">HostingUnit</param>
        public void AddUnit(HostingUnit newUnit)  
        {
            if (GetUnitsList().Any(x => x.HostingUnitKey == newUnit.HostingUnitKey))
            {
                throw new TzimerException($"Hosting Unit with the ID: {newUnit.HostingUnitKey} - already exists!", "dal");
            }
          
            newUnit.HostingUnitKey = Configuration.HostingUnitId++;
            DataSource.unitList.Add((HostingUnit)newUnit.Clone());
           

       }

        /// <summary>
        /// function who update hosting unit
        /// </summary>
        /// <param name="updatedUnit">hosting unit</param>
        public void UpdateUnit(HostingUnit updatedUnit)
        {
            DataSource.unitList = DataSource.unitList
               .Select(x => {
                   if(x.HostingUnitKey == updatedUnit.HostingUnitKey)
                   {
                       x = updatedUnit;
                   }
                    return (HostingUnit)x.Clone();
               })
               .ToList();
        }

        /// <summary>
        /// function who delete an unit
        /// </summary>
        /// <param name="delUnit">hosting unit</param>
        public void DeleteUnit(HostingUnit delUnit)
        {
            DataSource.unitList.RemoveAll(x => x.HostingUnitKey == delUnit.HostingUnitKey);
        }
        #endregion

        #region Orders

        public List<Order> GetOrdersList()
        {
            return (from d in DataSource.orderList
                    select (Order)d.Clone()).ToList();
        }

        public Order GetOrder(int id)
        {
            return (Order)DataSource.orderList.FirstOrDefault(x => x.OrderKey == id)?.Clone();
        }

        /// <summary>
        /// function who adding order
        /// </summary>
        /// <param name="newOrder">order</param>
        public void AddOrder(Order newOrder)
        {
            if (GetOrdersList().Any(x => x.OrderKey == newOrder.OrderKey))
            {
                throw new TzimerException($"Order with the ID: {newOrder.OrderKey} - already exists!", "dal");
            }
            newOrder.OrderKey = Configuration.OrderId++;
            DataSource.orderList.Add((Order)newOrder.Clone());
        }

        /// <summary>
        /// function who update the order
        /// </summary>
        /// <param name="updatedOrder">order</param>
        public void UpdateOrder(Order updatedOrder)
        {

            DataSource.orderList = DataSource.orderList
                 .Select(x =>
                 {
                     if (x.OrderKey == updatedOrder.OrderKey)
                     {
                         x.Status = updatedOrder.Status;
                     }
                     return (Order)x.Clone();
                 })
                 .ToList();
        }

        /// <summary>
        /// function who delete order.
        /// </summary>
        /// <param name="order">order</param>
        public void DeleteOrder(Order order)
        {
            DataSource.orderList.RemoveAll(x => x.OrderKey == order.OrderKey);
        }

        #endregion

        /// <summary>
        /// Quick reboot of bank list.
        /// </summary>
        /// <returns></returns>
        public List<BankBranch> GetBankList() 
        {
            return new List<BankBranch>
            {
                new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                },
                 new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                },
                  new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                },
                   new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                },
                    new BankBranch
                {
                    BankName = "Leumi",
                    BankNumber = 1,
                    BranchAddress = "Rechavia",
                    BranchCity = "Jerusalem",
                    BranchNumber = 123
                }
            };
        }
    }
}