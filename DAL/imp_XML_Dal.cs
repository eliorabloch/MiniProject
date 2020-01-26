using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;

namespace DAL
{
    class imp_XML_Dal : IDAL
    {
        private static imp_XML_Dal instance = null;

        public static imp_XML_Dal getInstance()
        {
            if (instance == null)
            {
                instance = new imp_XML_Dal();
            }
            return instance;
        }

        private imp_XML_Dal()
        {

        }

        private static readonly string HOSTING_UNITS = "HostingUnits";
        private static readonly string HOSTING_UNITS_FILENAME = HOSTING_UNITS + ".xml";
        private static readonly string GUEST_REQUESTS = "GuestRequests";
        private static readonly string GUEST_REQUESTS_FILENAME = GUEST_REQUESTS + ".xml";
        private static readonly string CONFIG_FILENAME = "Config.xml";
        private static readonly string ORDERS = "Orders";
        private static readonly string ORDERS_FILENAME = ORDERS + ".xml";

        private static int getKeyFromConfig(string keyName)
        {
            var conf = XElement.Load(CONFIG_FILENAME);
            int newKey = int.Parse(conf.Element(keyName).Value) + 1;
            conf.Element(keyName).Value = newKey.ToString();
            conf.Save(CONFIG_FILENAME);
            return newKey;
        }

        public double GetProfits()
        {
            var conf = XElement.Load(CONFIG_FILENAME);
            var res = double.Parse(conf.Element("Profits").Value);
            conf.Save(CONFIG_FILENAME);
            return res;
        }

        public void UpdateProfits(double days)
        {
            var conf = XElement.Load(CONFIG_FILENAME);
            double newCommition = double.Parse(conf.Element("Profits").Value) + (days * Configuration.Commissin);
            conf.Element("Profits").Value = newCommition.ToString();
            conf.Save(CONFIG_FILENAME);
        }

        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSer = new XmlSerializer(source.GetType());
            xmlSer.Serialize(file, source);
            file.Close();
        }

        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            T result = (T)xmlSer.Deserialize(file);
            file.Close();
            return result;
        }

        #region Guest Requests

        public List<GuestRequest> GetGuestRequestList()
        {
            return LoadFromXML<GuestRequests>(GUEST_REQUESTS_FILENAME);
        }

        public GuestRequest GetGuestRequest(int GuestRequestID)
        {
            return GetGuestRequestList().FirstOrDefault(x => x.GuestRequestKey == GuestRequestID);
        }

        public void AddGuestRequest(GuestRequest newGuestRequest)
        {
            newGuestRequest.GuestRequestKey = getKeyFromConfig("GuestRequestId");
            var grl = GetGuestRequestList();
            if (grl.Any(x => x.GuestRequestKey == newGuestRequest.GuestRequestKey))
            {
                throw new TzimerException($"Guest Request with the ID: {newGuestRequest.GuestRequestKey} - already exists!", "dal");
            }
            grl.Add(newGuestRequest);
            SaveToXML(grl, GUEST_REQUESTS_FILENAME);
        }

        public void DeleteGuestRequest(GuestRequest newGuestRequest)
        {
            var guestRequestsList = GetGuestRequestList();
            var succeed = guestRequestsList.RemoveAll(x => x.GuestRequestKey == newGuestRequest.GuestRequestKey);
            if (succeed == 0)
            {
                throw new TzimerException($"Failed to remove Guest Request, ID: {newGuestRequest.GuestRequestKey}", "dal");
            }
            SaveToXML(guestRequestsList, GUEST_REQUESTS_FILENAME);
        }

        public void UpdateGuestRequest(GuestRequest updatedGuestRequest)
        {
            var guestRequestsList = GetGuestRequestList();
            guestRequestsList.ForEach(x =>
            {
                if (x.GuestRequestKey == updatedGuestRequest.GuestRequestKey)
                {
                    x.Status = updatedGuestRequest.Status;
                }
            });
            SaveToXML(guestRequestsList, GUEST_REQUESTS_FILENAME);
        }

        #endregion

        #region Hosting Units
        
        public HostingUnit GetHostingUnit(int HostingUnitID)
        {
            return GetHostingUnitsList().FirstOrDefault(x => x.HostingUnitKey == HostingUnitID);
        }

        public void AddHostingUnit(HostingUnit newHostingUnit)
        {
            newHostingUnit.HostingUnitKey = getKeyFromConfig("HostingUnitId");
            newHostingUnit.Diary = Utils.CreateMatrix();
            var hostingUnitsList = GetHostingUnitsList();
            if (hostingUnitsList.Any(x => x.HostingUnitKey == newHostingUnit.HostingUnitKey))
            {
                throw new TzimerException($"Hosting Unit with the ID: {newHostingUnit.HostingUnitKey} - already exists!", "dal");
            }

            HostingUnits hostingUnitsLists = (HostingUnits)GetHostingUnitsList();
            hostingUnitsLists.Add(newHostingUnit);
            SaveToXML(hostingUnitsLists, HOSTING_UNITS_FILENAME);
        }

        public List<HostingUnit> GetHostingUnitsList()
        {
            List<HostingUnit> hostingUnitsList = LoadFromXML<HostingUnits>(HOSTING_UNITS_FILENAME);
            return hostingUnitsList;
        }

        public void UpdateHostingUnit(HostingUnit updateHostingUnit)
        {
            var hostingUnitsList = GetHostingUnitsList();
            var updatedList = hostingUnitsList.Select(x =>
            {
                if (x.HostingUnitKey == updateHostingUnit.HostingUnitKey)
                {
                    x = updateHostingUnit;
                }
                return x;
            }).ToList();
            SaveToXML(updatedList, HOSTING_UNITS_FILENAME);
        }

        public void DeleteHostingUnit(HostingUnit deleteHostingUnit)
        {
            var hostingUnitsList = GetHostingUnitsList();
            var succeed = hostingUnitsList.RemoveAll(x => x.HostingUnitKey == deleteHostingUnit.HostingUnitKey);
            if (succeed == 0)
            {
                throw new TzimerException($"Failed to remove Hosting Unit, ID: {deleteHostingUnit.HostingUnitKey}", "dal");
            }
            SaveToXML(hostingUnitsList, HOSTING_UNITS_FILENAME);
        }
        #endregion

        #region Orders
        public Order GetOrder(int id)
        {
            return GetOrdersList().FirstOrDefault(x => x.OrderKey == id);
        }

        public List<Order> GetOrdersList()
        {
            List<Order> orderList = new List<Order>();

            XElement orderlistxml = XElement.Load(ORDERS_FILENAME);
            foreach (var orderXml in orderlistxml.Elements())
            {
                orderList.Add(new Order
                {
                    GuestRequestKey = int.Parse(orderXml.Element("GuestRequestKey").Value),
                    HostingUnitKey = int.Parse(orderXml.Element("HostingUnitKey").Value),
                    OrderKey = int.Parse(orderXml.Element("OrderKey").Value),
                    Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), orderXml.Element("Status").Value),
                    CreateDate = DateTime.Parse(orderXml.Element("CreateDate").Value),
                    OrderDate = DateTime.Parse(orderXml.Element("OrderDate").Value),
                });
            }
            return orderList;
        }


        public void UpdateOrder(Order update)
        {
            XElement orderlistxml = XElement.Load(ORDERS_FILENAME);
            var oldOrder = orderlistxml.Elements().FirstOrDefault(x => int.Parse(x.Element("OrderKey").Value) == update.OrderKey);
            if (oldOrder == null)
            {
                throw new TzimerException($"Failed to update Order, cannot find order with ID: {update.OrderKey}");
            }
            oldOrder.Element("Status").Value = update.Status.ToString();
            orderlistxml.Save(ORDERS_FILENAME);
        }

        public void AddOrder(Order newOrder)
        {
            XElement orderlistxml = XElement.Load(ORDERS_FILENAME);
            newOrder.OrderKey = getKeyFromConfig("OrderId");

            var ol = GetOrdersList();
            if (ol.Any(x => x.OrderKey == newOrder.OrderKey))
            {
                throw new TzimerException($"Order with the ID: {newOrder.OrderKey} - already exists!", "dal");
            }

            orderlistxml.Add(new XElement("Order",
                new XElement("HostingUnitKey", newOrder.HostingUnitKey),
                new XElement("GuestRequestKey", newOrder.GuestRequestKey),
                new XElement("OrderKey", newOrder.OrderKey),
                new XElement("Status", newOrder.Status.ToString()),
                new XElement("CreateDate", newOrder.CreateDate.ToString()),
                new XElement("OrderDate", newOrder.OrderDate.ToString())
                ));
            orderlistxml.Save(ORDERS_FILENAME);
        }


        public void DeleteOrder(Order delOrder)
        {
            XElement orderlistxml = XElement.Load(ORDERS_FILENAME);
            var oldOrder = orderlistxml.Elements().FirstOrDefault(x => int.Parse(x.Element("OrderKey").Value) == delOrder.OrderKey);
            if (oldOrder == null)
            {
                throw new TzimerException($"Failed to delete Order, cannot find order with ID: {delOrder.OrderKey}");
            }
            oldOrder.Remove();
            orderlistxml.Save(ORDERS_FILENAME);
        }

        #endregion

        #region Host

        public List<Host> GetHostList()
        {
            return GetHostingUnitsList().Select(h => h.Owner).Distinct().ToList();
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
                if(!File.Exists(xmlLocalPath) || !File.ReadAllText(xmlLocalPath).ToLower().Contains("<atms"))
                {
                    throw new Exception("try again");
                }
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

            if (!File.Exists(xmlLocalPath))
            {
                throw new TzimerException("Failed to pull bank list", "dal");
            }

            List<BankBranch> branches = new List<BankBranch>();
            XElement xElement = XElement.Load(xmlLocalPath);
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

        public void UpdateHost(Host owner)
        {
            var ReleventUnitKeyList = (from unit in GetUnitsList()
                                       where unit.Owner.HostId == owner.HostId
                                       let newOwner = owner
                                       select new { unitKey = unit.HostingUnitKey }).Select(x => x.unitKey).ToList();


            var updatedList = GetUnitsList().Select(x =>
            {
                if (ReleventUnitKeyList.Contains(x.HostingUnitKey))
                {
                    x.Owner = owner;
                }
                return x;
            }).ToList();

            SaveToXML(updatedList, HOSTING_UNITS_FILENAME);
        }

      
    }
}
