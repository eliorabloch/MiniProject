using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankAccount
    {
        int BankNumber { get; set; }
        public int BranchNumber { get; set; } 
        int BankAccountNumber { get; set; }
        public string BankName { get; set; }
        string BranchAddress { get; set; }
        string BranchCity { get; set; }
        string ToString { get; set; }
    }
}
