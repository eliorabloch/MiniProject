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
        //public static int tempOrderKey = 20000001;
        private int orderKey;
        public int OrderKey {
            get { return orderKey; }
            set { orderKey = Configuration.OrderId++; }
        }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string ToString { get; set; }
        public Order() { }//defult constructor

        public object Clone()
        {
            return MemberwiseClone();
        }

        //public Order(GuestRequest newGuastRequest)
        //{
        //    GuestRequestKey = newGuastRequest.GuestRequestKey;
        //    OrderKey = tempOrderKey;
        //    tempOrderKey++;
        //    Status = OrderStatus.NotHandled;
        //    CreateDate = DateTime.Now.Date;
        //}
    }
}
