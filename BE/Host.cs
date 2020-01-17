using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host : ICloneable
    {
        public int numOfUnits { get; set; }
        public string HostId { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public BankBranch BankAccuont { get; set; }
        public bool CollectionClearance { get; set; }
        public string BankAccountNumber { get; set; }
        public string toString { get; set; }
      
        public override string ToString()//A print function that prints all the details of the class
        {
            toString = "";
            toString += "this is your host information: \n";
            toString += $"Host key: {HostId} \n";
            toString += $"Private name: {PrivateName} \n";
            toString += $"Family name: {FamilyName} \n";
            toString += $"Phone number: {PhoneNumber} \n";
            toString += $"Mail address: {MailAddress} \n";
            toString += $"Bank accuont: {BankAccuont} \n";
            toString += $"Number Of Units: {numOfUnits} \n";
            toString += $"Collection clearance: {CollectionClearance} \n";
            toString += $"Bank account number: {BankAccountNumber} \n";
            return toString;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
       

        public Host() {}//defult constructor

    }
}

