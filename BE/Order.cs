using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey;
        public int GuestRequestKey { get; set; }
        //public static int tempOrderKey = 20000001;
        public int OrderKey { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string ToString { get; set; }
        public Order() { }//defult constructor

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
