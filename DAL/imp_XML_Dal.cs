using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private static int getKeyFromConfig(string keyName)
        {
            var conf = XElement.Load(CONFIG_FILENAME);
            int newKey = int.Parse(conf.Element(keyName).Value) + 1;
            conf.Element(keyName).Value = newKey.ToString();
            conf.Save(CONFIG_FILENAME);
            return newKey;
        }

        #region Guest Requests
        public List<GuestRequest> GetGuestRequestList()
        {
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
            new XmlSerializer(typeof(GuestRequests));
            GuestRequests grl = null;
            using (Stream reader = new FileStream(GUEST_REQUESTS_FILENAME, FileMode.Open))
            {
                grl = (GuestRequests)serializer.Deserialize(reader);
            }
            return grl;
        }

        public GuestRequest GetRequest(int id)
        {
            return GetGuestRequestList().FirstOrDefault(x => x.GuestRequestKey == id);
        }

        public void AddRequest(GuestRequest newRequest)
        {
            newRequest.GuestRequestKey = getKeyFromConfig("GuestRequestId");
            var grl = GetGuestRequestList();
            if (grl.Any(x => x.GuestRequestKey == newRequest.GuestRequestKey))
            {
                throw new TzimerException($"Guest Request with the ID: {newRequest.GuestRequestKey} - already exists!", "dal");
            }
            grl.Add(newRequest);
            updateGuestRequestXmlFile(grl);
        }



        public void DeleteRequest(GuestRequest newRequest)
        {
            var grl = GetGuestRequestList();
            var succeed = grl.RemoveAll(x => x.GuestRequestKey == newRequest.GuestRequestKey);
            if (succeed == 0)
            {
                throw new TzimerException($"Failed to remove Guest Request, ID: {newRequest.GuestRequestKey}", "dal");
            }
            updateGuestRequestXmlFile(grl);
        }

        public void UpdateRequest(GuestRequest updatedRequest)
        {
            var grl = GetGuestRequestList();
            grl.ForEach(x =>
            {
                if (x.GuestRequestKey == updatedRequest.GuestRequestKey)
                {
                    x.Status = updatedRequest.Status;
                }
            });
            updateGuestRequestXmlFile(grl);
        }

        private static void updateGuestRequestXmlFile(List<GuestRequest> grl)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GuestRequests));
            //xmlSerializer.Serialize(newRequest);
            Stream fs = new FileStream(GUEST_REQUESTS_FILENAME, FileMode.Create);
            XmlWriter writer =
            new XmlTextWriter(fs, new UTF8Encoding());
            // Serialize using the XmlTextWriter.
            xmlSerializer.Serialize(writer, grl);
        } 
        #endregion

        public void AddOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }



        public void AddUnit(HostingUnit newUnit)
        {
            throw new NotImplementedException();
        } 

        public void DeleteOrder(Order update)
        {
            throw new NotImplementedException();
        }

      

        public void DeleteUnit(HostingUnit delUnit)
        {
            throw new NotImplementedException();
        }

        public List<BankBranch> GetBankList()
        {
            throw new NotImplementedException();
        }


        public List<Host> GetHostList()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersList()
        {
            throw new NotImplementedException();
        }

        public HostingUnit GetUnit(int id)
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> GetUnitsList()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order update)
        {
            throw new NotImplementedException();
        }

    

        public void UpdateUnit(HostingUnit update)
        {
            throw new NotImplementedException();
        }
    }
}
