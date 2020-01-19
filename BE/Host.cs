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
        public BankBranch BankBranchDetails { get; set; }
        public bool CollectionClearance { get; set; }
        public string BankAccountNumber { get; set; }
        public string toString { get; set; }

        /// <summary>
        /// A print function that prints all the details of the class
        /// </summary>
        /// <returns>the host details.</returns>
        public override string ToString()
        {
            toString = "";
            toString += "this is your host information: \n";
            toString += $"Host key: {HostId} \n";
            toString += $"Private name: {PrivateName} \n";
            toString += $"Family name: {FamilyName} \n";
            toString += $"Phone number: {PhoneNumber} \n";
            toString += $"Mail address: {MailAddress} \n";
            toString += $"Bank accuont: {BankBranchDetails} \n";
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

