using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        int ID;
        public static int HostingUnitKey = 10000001;
        int GuestRequestKey { get; set; }
        static int tempOrderKey = 20000001;
         int OrderKey { get; set; }

       public OrderStatus Status { get; set; }
      public  DateTime CreateDate { get; set; }
     public   DateTime OrderDate { get; set; }
        string ToString { get; set; }
       public Order( GuestRequest newGuastRequest)
        {
            GuestRequestKey = newGuastRequest.GuestRequestKey;
            OrderKey = tempOrderKey;
            tempOrderKey++;
            Status = OrderStatus.NotHandled;
            CreateDate = DateTime.Now.Date;
            
 }
    }
}
