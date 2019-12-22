using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
     public class Host
    {
        
       public int HostKey { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; }
        public  string MailAddress { get; set; }
        public BankBranch BankAccuont { get; set; }
        public bool CollectionClearance { get; set; }
        public string toString { get; set; }
        public List<HostingUnit> HostingUnitCollection { get; set; }

        public override string ToString()
        {
           toString = "";
            foreach (var item in HostingUnitCollection)
            {
               toString += item + "\n";
            }
            return toString;
        }
        public Host() { HostingUnitCollection = new List<HostingUnit>(); }
        public Host(int hk, int numOfUnits)//constructor
        {
            HostingUnitCollection = new List<HostingUnit>();
            for (int i = 0; i < numOfUnits; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }
            HostKey = hk;

        }
    }
}
