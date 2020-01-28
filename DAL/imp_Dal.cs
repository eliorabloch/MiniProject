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
            //  DataSource.Init();
        }

        #region Guest Requst

        public List<GuestRequest> GetGuestRequestList()
        {
            return (from guestrequest in DataSource.requestList
                    select (GuestRequest)guestrequest.Clone()).ToList();
        }

        public GuestRequest GetGuestRequest(int id)
        {
            return (GuestRequest)GetGuestRequestList().FirstOrDefault(x => x.GuestRequestKey == id)?.Clone();
        }

         public void AddGuestRequest(GuestRequest newGuestRequest)
        {
            if (GetGuestRequestList().Any(x => x.GuestRequestKey == newGuestRequest.GuestRequestKey))
            {
                throw new TzimerException($"Guest Request with the ID: {newGuestRequest.GuestRequestKey} - already exists!", "dal");
            }
            newGuestRequest.GuestRequestKey = Configuration.GuestRequestId++;
            DataSource.requestList.Add((GuestRequest)newGuestRequest.Clone());
        }
        
        public void UpdateGuestRequest(GuestRequest updatedGuestRequest)
        {
            DataSource.requestList.ForEach(x =>
            {
                if (x.GuestRequestKey == updatedGuestRequest.GuestRequestKey)
                {
                    x.Status = updatedGuestRequest.Status;
                }
            });

        }
        
        public void DeleteGuestRequest(GuestRequest newGuestRequest)
        {
            DataSource.requestList.RemoveAll(x => x.GuestRequestKey == newGuestRequest.GuestRequestKey);
        }

        #endregion

        #region Hosting Units

        public List<HostingUnit> GetHostingUnitsList()
        {
            return (from hostingunit in DataSource.unitList
                    select (HostingUnit)hostingunit.Clone()).ToList();
        }

        public HostingUnit GetHostingUnit(int id)
        {
            return (HostingUnit)DataSource.unitList.FirstOrDefault(x => x.HostingUnitKey == id)?.Clone();
        }
        
        public void AddHostingUnit(HostingUnit newHostingUnit)
        {
            if (GetHostingUnitsList().Any(x => x.HostingUnitKey == newHostingUnit.HostingUnitKey))
            {
                throw new TzimerException($"Hosting Unit with the ID: {newHostingUnit.HostingUnitKey} - already exists!", "dal");
            }

            newHostingUnit.HostingUnitKey = Configuration.HostingUnitId++;
            newHostingUnit.Diary = Utils.CreateMatrix();
            DataSource.unitList.Add((HostingUnit)newHostingUnit.Clone());


        }
        
        public void UpdateHostingUnit(HostingUnit updatedHostingUnit)
        {
            DataSource.unitList = DataSource.unitList
               .Select(x => {
                   if (x.HostingUnitKey == updatedHostingUnit.HostingUnitKey)
                   {
                       x = updatedHostingUnit;
                   }
                   return (HostingUnit)x.Clone();
               })
               .ToList();
        }
        
        public void DeleteHostingUnit(HostingUnit deleteHostingUnit)
        {
            DataSource.unitList.RemoveAll(x => x.HostingUnitKey == deleteHostingUnit.HostingUnitKey);
        }

        #endregion

        #region Host

        public List<Host> GetHostList()
        {
            return DataSource.unitList.Select(h => (Host)h.Owner.Clone()).Distinct().ToList();
        }

        #endregion

        #region Orders

        public List<Order> GetOrdersList()
        {
            return (from order in DataSource.orderList
                    select (Order)order.Clone()).ToList();
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

        #region Bank Branch 
        
        public List<BankBranch> GetBankList()
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

            if (!File.Exists(@"BankBranches.xml"))
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

        #endregion

        #region More

        public void UpdateProfits(double days)
        {
            Configuration.Profits += (days * Configuration.Commissin);
        }

        public void UpdateHost(Host owner)
        {
            var ReleventUnitKeyList = (from unit in GetHostingUnitsList()
                                       where unit.Owner.HostId == owner.HostId
                                       let newOwner = owner
                                       select new { unitKey = unit.HostingUnitKey }).Select(x => x.unitKey).ToList();


            foreach (var hostUnit in DataSource.unitList.Where(x => ReleventUnitKeyList.Contains(x.HostingUnitKey)))
            {
                hostUnit.Owner = owner;
            }
        }

        public double GetProfits()
        {
            return Configuration.Profits;
        }

        #endregion

    }
}