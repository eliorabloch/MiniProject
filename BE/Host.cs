using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Host
    {
        int HostKey { get; set; }
        string PrivateName { get; set; }
        string FamilyName { get; set; }
        string PhoneNumber { get; set; }
        string MailAddress { get; set; }
        BankAccount BankAccuont { get; set; }
        bool CollectionClearance { get; set; }
        string toString { get; set; }
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
