using BE;
using DS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class imp_Dal : IDAL
    {
        
        
        //Using Singleton makes sure that no new instance of the class is ever created but only one instance.
        private static imp_Dal instance = null;

        public static imp_Dal getInstance()
        {
            if (instance == null)
            {
                instance = new imp_Dal();
            }
            return instance;
        }

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

        public void AddRequest(GuestRequest newRequest)
        {
            if(GetGuestRequestList().Any(x => x.GuestRequestKey == newRequest.GuestRequestKey))
            {
                throw new TzimerException($"Guest Request with the ID: {newRequest.GuestRequestKey} - already exists!", "dal");
            }
            newRequest.GuestRequestKey = Configuration.GuestRequestId++;
            DataSource.requestList.Add((GuestRequest)newRequest.Clone());
        }

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
            //return (from h in DataSource.unitList
            //        select (Host)h.Owner.Clone()).Distinct().ToList();
            return DataSource.unitList.Select(h=> (Host)h.Owner.Clone()).Distinct().ToList();

        }

        public HostingUnit GetUnit(int id)
        {
            return (HostingUnit)DataSource.unitList.FirstOrDefault(x => x.HostingUnitKey == id)?.Clone();
        }

        public void AddUnit(HostingUnit newUnit)  
        {
            if (GetUnitsList().Any(x => x.HostingUnitKey == newUnit.HostingUnitKey))
            {
                throw new TzimerException($"Hosting Unit with the ID: {newUnit.HostingUnitKey} - already exists!", "dal");
            }
          
            newUnit.HostingUnitKey = Configuration.HostingUnitId++;
            DataSource.unitList.Add((HostingUnit)newUnit.Clone());
           

       }

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

        public void AddOrder(Order newOrder)
        {
            if (GetOrdersList().Any(x => x.OrderKey == newOrder.OrderKey))
            {
                throw new TzimerException($"Order with the ID: {newOrder.OrderKey} - already exists!", "dal");
            }
            newOrder.OrderKey = Configuration.OrderId++;
            DataSource.orderList.Add((Order)newOrder.Clone());
        }

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


        public void DeleteOrder(Order order)
        {
            DataSource.orderList.RemoveAll(x => x.OrderKey == order.OrderKey);
        }

        #endregion

        public List<BankBranch> GetBankList() //Quick reboot of bank list.
        {

            const string xmlLocalPath = @"BankBranches.xml";
            WebClient wc = new WebClient();
            try
            {
                string xmlServerPath =
               @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";

                wc.DownloadFile(xmlServerPath, xmlLocalPath);
            }
            catch (Exception)
            {
                string xmlServerPath = @"http://homedir.jct.ac.il/~coshri/atm.xml";
                wc.DownloadFile(xmlServerPath, xmlLocalPath);
            }
            finally
            {
                wc.Dispose();
            }

            if(!File.Exists(@"BankBranches.xml"))
            {
                throw new TzimerException("Failed to pull bank list", "dal");
            }

            List<BankBranch> branches = new List<BankBranch>();
            XElement xElement = XElement.Load(@"BankBranches.xml");
            foreach (var item in xElement.Elements())
            {
                branches.Add(new BankBranch()
                {
                    BranchAddress = item.Element("כתובת_ה-ATM").Value,
                    BankNumber = int.Parse(item.Element("קוד_בנק").Value),
                    BankName = item.Element("שם_בנק").Value,
                    BranchCity = item.Element("ישוב").Value,
                    BranchNumber = int.Parse(item.Element("קוד_סניף").Value)
                });
              
            }
            return branches.GroupBy(x => x.BranchNumber).Select(y => y.FirstOrDefault()).ToList();
        }
    }
}