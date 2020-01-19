using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order : ICloneable
    {
        public int HostingUnitKey { get; set; }
        public int GuestRequestKey { get; set; }
        public int OrderKey{get; set;}
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OrderDate { get; set; }
        public Order() { }//defult constructor

        /// <summary>
        /// A print function that prints all the details of the class
        /// </summary>
        /// <returns>the order details.</returns>
        public override string ToString()
        {
            string toString = "";
            toString += "this is your order information: \n";
            toString += $"Hosting unit key: {HostingUnitKey} \n";
            toString += $"Guest request key: {GuestRequestKey} \n";
            toString += $"order key: {OrderKey} \n";
            toString += $"Status: {Status} \n";
            toString += $"Create date: {CreateDate} \n";
            toString += $"Order date: {OrderDate} \n";
            return toString;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
