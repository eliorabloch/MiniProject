using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
     public class Host: ICloneable
    {
        public string HostKey { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; }
        public  string MailAddress { get; set; }
        public BankBranch BankAccuont { get; set; }
        public bool CollectionClearance { get; set; }
        public uint BankAccountNumber { get;set;}
        public string toString { get; set; }
        public override string ToString()
        {
           toString = "";
            //foreach (var item in HostingUnitCollection)
            //{
            //   toString += item + "\n";
            //}
            return toString;
        }

        public object Clone()
        {
            throw new MemberAccessException();
        }

        public Host() { }//defult constructor
    }
}
