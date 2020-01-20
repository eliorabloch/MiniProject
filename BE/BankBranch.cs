using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch : ICloneable
    {
        public int BankNumber { get; set; }
        public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }

        public BankBranch() { }

        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// A print function that prints all the details of the class
        /// </summary>
        /// <returns>the bank branch details.</returns>
        public override string ToString()
        {
            string toString = "";
           
            toString += $"Bank number: {BankNumber} \n";
            toString += $"Bank name: {BankName} \n";
            toString += $"Branch number: {BranchNumber} \n";
            toString += $"Branch address: {BranchAddress} \n";
            toString += $"Branch city: {BranchCity} \n";
            return toString;
        }
       
    }
};
